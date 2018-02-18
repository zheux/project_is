using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCRS.Domain;

namespace GCRS.Web.ViewModels
{
    public class NomencladorViewModel
    {
        public List<Provincia> Provincias { get; set; }
        public List<Municipio> Municipios { get; set; }
        public List<Reparto> Repartos { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<UnidadTiempoRenta> UnidadesTiempoRenta { get; set; }
    }
}