using System.ComponentModel.DataAnnotations.Schema;

namespace GCRS.Domain
{
    public class Property
    {
        public int Id { get; set; }
        public int RoomsCount { get; set; }

        [ForeignKey ("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey ("Province")]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        [ForeignKey ("District")]
        public int DistrictId { get; set; }
        public District District { get; set; }

        [ForeignKey ("Municipality")]
        public int MunicipalityId { get; set; }
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
