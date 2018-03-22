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
            if(context.Agents.SingleOrDefault(m => m.Username == "agente") == null)
                context.Agents.AddOrUpdate(new Agent() { Username = "agente", Password = "123456", Email = "test2@gmail.com" });

            if(context.Categories.SingleOrDefault(m => m.Name == "Simple") == null)
                context.Categories.AddOrUpdate(new Category() { Name = "Simple" });
            if (context.Categories.SingleOrDefault(m => m.Name == "Suite") == null)
                context.Categories.AddOrUpdate(new Category() { Name = "Suite" });
            if (context.Provinces.SingleOrDefault(m => m.Name == "La Habana") == null)
                context.Provinces.AddOrUpdate(new Province() { Name = "La Habana" });
            if (context.Provinces.SingleOrDefault(m => m.Name == "Matanzas") == null)
                context.Provinces.AddOrUpdate(new Province() { Name = "Matanzas" });
            if (context.Municipalities.SingleOrDefault(m => m.Name == "Vedado") == null)
                context.Municipalities.AddOrUpdate(new Municipality() { Name = "Vedado" });
            if(context.Districts.SingleOrDefault(m => m.Name == "Nuevo Vedado") == null)
                    context.Districts.AddOrUpdate(new District() { Name = "Nuevo Vedado" });
            if(context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche") == null)
                context.RentTimeUnits.AddOrUpdate(new RentTimeUnit() { Name = "Noche" });

            context.SaveChanges();

            Property testProp = new Property()
            {
                Direccion = "23 entre 20 y 22",
                Category = context.Categories.SingleOrDefault(m => m.Name == "Simple"),
                Province = context.Provinces.SingleOrDefault(m => m.Name == "La Habana"),
                Municipality = context.Municipalities.SingleOrDefault(m => m.Name == "Vedado"),
                District = context.Districts.SingleOrDefault(m => m.Name == "Nuevo Vedado"),
                RoomsCount = 1
            };

            Property testProp2 = new Property()
            {
                Direccion = "Matanzas",
                Category = context.Categories.SingleOrDefault(m => m.Name == "Suite"),
                Province = context.Provinces.SingleOrDefault(m => m.Name == "Matanzas"),
                RoomsCount = 1
            };

            context.Properties.Add(testProp);
            context.Properties.Add(testProp2);
            context.SaveChanges();

            RentalOffer o = new RentalOffer()
            {
                Title = "Hostal Clara",
                Description = "Descripcion del hostal",
                PricePerRTU = 80,
                RTU = context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche"),
                Property = testProp,
                State = State.Published
            };

            RentalOffer p = new RentalOffer()
            {
                Title = "Apartamento",
                Description = "Descripcion del apartamento",
                PricePerRTU = 50,
                RTU = context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche"),
                Property = testProp,
                State = State.Published
            };

            RentalOffer q = new RentalOffer()
            {
                Title = "Alquiler Suite Romantic Matanzas",
                Description = "Descripcion del alquiler",
                PricePerRTU = 120,
                RTU = context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche"),
                Property = testProp2,
                State = State.Published
            };

            RentalOffer r = new RentalOffer()
            {
                Title = "Casa independiente",
                Description = "Descripcion de la casa",
                PricePerRTU = 160,
                RTU = context.RentTimeUnits.SingleOrDefault(m => m.Name == "Noche"),
                Property = testProp2,
                State = State.Published
            };

            context.RentalOffers.Add(o);
            context.RentalOffers.Add(p);
            context.RentalOffers.Add(q);
            context.RentalOffers.Add(r);

            context.SaveChanges();

            context.Reservations.Add(new Reservation() {
                ClientUsername = context.Clients.Single(m => m.Username == "cliente").Username,
                Client = context.Clients.Single(m => m.Username == "cliente"),
                RentalOfferId = context.RentalOffers.Single(m => m.Title == "Apartamento").Id,
                RentalOffer = context.RentalOffers.Single(m => m.Title == "Apartamento"),
                ArrivalDate = new DateTime(2018, 1, 1, 12, 0, 0),
                DepartureDate = new DateTime(2018, 1, 10, 12, 0, 0)
            });

            context.Reservations.Add(new Reservation()
            {
                ClientUsername = context.Clients.Single(m => m.Username == "cliente").Username,
                Client = context.Clients.Single(m => m.Username == "cliente"),
                RentalOfferId = context.RentalOffers.Single(m => m.Title == "Alquiler Suite Romantic Matanzas").Id,
                RentalOffer = context.RentalOffers.Single(m => m.Title == "Alquiler Suite Romantic Matanzas"),
                ArrivalDate = new DateTime(2018, 1, 20, 12, 0, 0),
                DepartureDate = new DateTime(2018, 1, 30, 12, 0, 0)
            });

            context.Reservations.Add(new Reservation()
            {
                ClientUsername = context.Clients.Single(m => m.Username == "cliente").Username,
                Client = context.Clients.Single(m => m.Username == "cliente"),
                RentalOfferId = context.RentalOffers.Single(m => m.Title == "Casa independiente").Id,
                RentalOffer = context.RentalOffers.Single(m => m.Title == "Casa independiente"),
                ArrivalDate = new DateTime(2018, 1, 25, 12, 0, 0),
                DepartureDate = new DateTime(2018, 1, 30, 12, 0, 0)
            });

            context.Reservations.Add(new Reservation()
            {
                ClientUsername = context.Clients.Single(m => m.Username == "cliente").Username,
                Client = context.Clients.Single(m => m.Username == "cliente"),
                RentalOfferId = context.RentalOffers.Single(m => m.Title == "Hostal Clara").Id,
                RentalOffer = context.RentalOffers.Single(m => m.Title == "Hostal Clara"),
                ArrivalDate = new DateTime(2018, 2, 1, 12, 0, 0),
                DepartureDate = new DateTime(2018, 2, 10, 12, 0, 0)
            });

            context.SaveChanges();

            context.SellOffers.Add(new SellOffer()
            {
                Title = "Apartamento",
                Description = "Descripcion del apartamento",
                Price = 5000,
                Property = testProp,
                State = State.Published
            });


            context.SellOffers.Add(new SellOffer()
            {
                Title = "Casa",
                Description = "Descripcion de la casa",
                Price = 20000,
                Property = testProp2,
                State = State.Published
            });

            context.SaveChanges();
        }
    }
}