namespace GCRS.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GCRS.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<GCRS.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GCRS.Data.ApplicationDbContext context)
        {
            context.Admins.AddOrUpdate(new Admin() { Username = "admin", Password = "123456", Email = "test@gmail.com" });
            context.Clients.AddOrUpdate(new Client() { Username = "cliente", Password = "123456", Email = "test1@gmail.com" });
            context.Agents.AddOrUpdate(new Agent() { Username = "agente", Password = "123456", Email = "test2@gmail.com" });

            context.Categories.AddOrUpdate(new Category() { Name = "Simple" });
            context.Provinces.AddOrUpdate(new Province() { Name = "La Habana" });
            context.Municipalities.AddOrUpdate(new Municipality() { Name = "Vedado" });
            context.Districts.AddOrUpdate(new District() { Name = "Miramar" });
            context.RentTimeUnits.AddOrUpdate(new RentTimeUnit() { Name = "Noche" });
        }
    }
}
