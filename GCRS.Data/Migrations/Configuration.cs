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
            if(context.Admins.SingleOrDefault(m => m.Username == "admin") == null)
                context.Admins.AddOrUpdate(new Admin() { Username = "admin", Password = "123456", Email = "test@gmail.com" });
            if(context.Clients.SingleOrDefault(m => m.Username == "cliente") == null)
                context.Clients.AddOrUpdate(new Client() { Username = "cliente", Password = "123456", Email = "test1@gmail.com" });
            if(context.Agents.SingleOrDefault(m => m.Username == "agente") != null)
                context.Agents.AddOrUpdate(new Agent() { Username = "agente", Password = "123456", Email = "test2@gmail.com" });

            if(context.Categories.SingleOrDefault(m => m.Name == "Simple") == null)
                context.Categories.AddOrUpdate(new Category() { Name = "Simple" });
            if(context.Provinces.SingleOrDefault(m => m.Name == "La Habana") == null)
                context.Provinces.AddOrUpdate(new Province() { Name = "La Habana" });
            if(context.Municipalities.SingleOrDefault(m => m.Name == "Vedado") == null)
                context.Municipalities.AddOrUpdate(new Municipality() { Name = "Vedado" });
            if(context.Districts.SingleOrDefault(m => m.Name == "Miramar") == null)
                    context.Districts.AddOrUpdate(new District() { Name = "Miramar" });
            if(context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche") == null)
                context.RentTimeUnits.AddOrUpdate(new RentTimeUnit() { Name = "Noche" });
        }
    }
}
