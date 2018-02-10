using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public class Cliente:Usuario
    {
        public List<Oferta> Demanda { get; set; }
        public List<Oferta> Solicitado { get; set; }
    }
}
