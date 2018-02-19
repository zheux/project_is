namespace GCRS.Domain
{
    public class Inmueble
    {
        public int Id { get; set; }
        public int CantHabitaciones { get; set; }
        public Categoria Categoria { get; set; }
        public Provincia Provincia { get; set; }
        public Reparto Reparto { get; set; }
        public Municipio Municipio { get; set; }
        public string Direccion { get; set; }
        public string InfoAdicional { get; set; }
    }

    #region Nomencladores
    public class Reparto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class UnidadTiempoRenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    #endregion

}
