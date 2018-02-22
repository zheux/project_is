using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GCRS.Domain;

namespace GCRS.Data
{
    class ApplicationDbContext : DbContext
    {
        //Nomencladores
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RentTimeUnit> RentTimeUnits { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public ApplicationDbContext() : base("name=db")
        {

        }
    }
}
