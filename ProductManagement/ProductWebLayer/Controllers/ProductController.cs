using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductDataAccessLayer;
using ProductWebLayer.Models;

namespace ProductWebLayer.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// This is to get the existing product details.
        /// </summary>
        /// <returns></returns>
        // GET: Product
        public ActionResult Index()
        {
            ProductDBContext context = new ProductDBContext();

            // For better decoupling I have used view model instead of directly using entity class in view.
            //Fetch the data from database and map to View model- Viewmodel is used becuse the view may need to show other details in future.

            IList<ProductViewModel> productList = context.MyProducts.Select(p => new ProductViewModel
            {
                ProductColor = p.ProductColor
            ,
                ProductPrice = p.ProductPrice
            ,
                ProductSku = p.ProductSku
            ,
                ProductStock = p.ProductStock
            ,
                ProductStyle = p.ProductStyle
            ,
                ProductTitle = p.ProductTitle
            }).ToList();

            return View(productList);
        }


        /// <summary>
        /// This is to add the product. The method results view to input the product details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ProductDBContext context = new ProductDBContext();
            return View();
        }

        /// <summary>
        /// This method insert the user entered product details to database.
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            ProductDBContext context = new ProductDBContext();

            // For better decoupling I have used view model instead of directly using entity class in view.

            Product product = new Product
            {
                ProductColor = productViewModel.ProductColor,
                ProductPrice = productViewModel.ProductPrice,
                ProductSku = productViewModel.ProductSku,
                ProductStock = productViewModel.ProductStock,
                ProductStyle = productViewModel.ProductStyle,
                ProductTitle = productViewModel.ProductTitle
            };

            //Insert to database.
            context.MyProducts.Add(product);
            context.SaveChanges();

            return View("Success");
        }

        /// <summary>
        /// Handling controller level exception.
        /// </summary>
        /// <param name="filterContext"></param>
        //Error loggig and disply.
        protected override void OnException(ExceptionContext filterContext)
        {
            //Log the error to file or console.
            Console.WriteLine("Error while processing Product");

            RedirectToAction("ProductError");
        }

        /// <summary>
        /// To display controller level error .
        /// </summary>
        /// <returns>Error view specific to this controller.</returns>
        public ActionResult Error()
        {
            return View("ProductError");
        }
    }
}