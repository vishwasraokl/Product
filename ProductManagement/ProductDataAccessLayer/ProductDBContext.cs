namespace ProductDataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductDBContext : DbContext
    {
        // Your context has been configured to use a 'ProductEntityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductDataAccessLayer.ProductEntityModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductEntityModel' 
        // connection string in the application configuration file.
        public ProductDBContext()
            : base("name=ProductEntityModel")
        {
            Database.SetInitializer(new ProductDBInitializer());

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> MyProducts { get; set; }
    }
    
}