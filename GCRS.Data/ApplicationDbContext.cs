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
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Reparto> Repartos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadTiempoRenta> UnidadesTiempoRenta { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public ApplicationDbContext() : base("name=db")
        {

        }
    }
}
