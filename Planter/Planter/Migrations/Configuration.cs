namespace Planter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Planter.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Planter.Models.PlanterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Planter.Models.PlanterContext context)
        {
            context.Plants.AddOrUpdate(x => x.Id,
                new Plant() {
                    Id =1,
                    Name ="Radish",
                    Description="A quick growing root vegetable",
                    Harvest="30 Days for most varietes", 
                    Germination=4,
                    Space="You can plant radishes about 3 inches apart",
                    Price=2,
                    Water="Water every other day"
                },
                new Plant() {
                    Id =2,
                    Name ="Carrot",
                    Description="A quick growing root vegetable",
                    Harvest="50 Days for most varietes", 
                    Germination=7,
                    Space="You can plant carrots about 2 inches apart",
                    Price=1,
                    Water="Water every day"
                }
            );
        }
    }
}
