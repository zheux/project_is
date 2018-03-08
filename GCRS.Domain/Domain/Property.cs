namespace GCRS.Domain
{
    public class Property
    {
        public int Id { get; set; }
        public int RoomsCount { get; set; }
        public Category Category { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
        public Municipality Municipality { get; set; }
        public string Direccion { get; set; }
        public string InfoAdicional { get; set; }
    }

    #region Nomencladores
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RentTimeUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion

}
