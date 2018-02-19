using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public enum Estado { Solicitado, Borrador, Publicado, Pagado, Cancelado };
    public class Oferta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Inmueble Inmueble { get; set; }
        public Agente Agente { get; set; }
        public Estado Estado { get; set; }
        public uint Comision { get; set; }
    }
}
