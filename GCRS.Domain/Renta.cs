using System;

namespace GCRS.Domain
{

    public class Renta:Oferta
    {
        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }
        public int PrecioxUTR { get; set; }
        public int CantUTR { get; set; }
        public UnidadTiempoRenta UTR { get; set; }
    }
}
