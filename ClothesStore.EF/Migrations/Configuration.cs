namespace ClothesStore.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClothesStore.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ClothesStore.EF.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClothesStore.EF.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(x => x.ProductId, new Product
            {
                ProductId = 1,
                Name = "TEETH PROBLEMS",
                Category = "T-SHIRT",
                Info = "100% Cotton\nIf u want one. Add in description \"I want one pls\"",
                Price = 65
            }, 
            new Product { 
                ProductId = 2,
                Name = "HEAD PROBLEMS",
                Category = "T-SHIRT",
                Info = "100% Cotton\nthoughts in my head",
                Price = 65
            },
             new Product
             {
                 ProductId = 3,
                 Name = "THE BJORK",
                 Category = "KNIT SWEATER",
                 Info = "2 SIDED SWEATER WITH FULL JACQUARD\nSWEATER MADE FROM EXPENSIVE MERINOS YARN\nOVERSIZED BAGGY FIT\nWarm.Good for winter",
                Price = 145
             });
        }
    }
}
