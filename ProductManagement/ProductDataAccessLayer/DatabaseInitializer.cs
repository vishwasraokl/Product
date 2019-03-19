using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDataAccessLayer
{

        public class ProductDBInitializer : DropCreateDatabaseIfModelChanges<ProductDBContext>
        {
            protected override void Seed(ProductDBContext context)
            {
                IList<Product> defautProducts = new List<Product>();

            defautProducts.Add(new Product() { ProductTitle = "Product 1", ProductColor = "RED" , ProductPrice=10.5, ProductSku="ProductSKU1", ProductStyle="Normal", ProductId=100 });
            
                context.MyProducts.AddRange(defautProducts);

                base.Seed(context);
            }
        }

             
}
