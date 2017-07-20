namespace Plantr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Plantr.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Plantr.Models.PlantrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Plantr.Models.PlantrContext context)
        {
            context.Plants.AddOrUpdate(x => x.Id,
                   new Plant() { Id = 1, Name = "Orchid" },
                   new Plant() { Id = 2, Name = "Kale" },
                   new Plant() { Id = 3, Name = "Radish" }
                   );

            context.PlantInfoes.AddOrUpdate(x => x.Id,
                new PlantInfo()
                {
                    Id = 1,
                    PlantId = 1,
                    Catagory = "Flower",
                    Price = 1  
                },
                new PlantInfo()
                {
                    Id = 2,
                    PlantId = 2,
                    Catagory = "Veggie",
                    Price = 1
                },
                new PlantInfo()
                {
                    Id = 3,
                    PlantId = 3,
                    Catagory = "Veggie",
                    Price = 4M,
                }
                );
        }
    }
}
