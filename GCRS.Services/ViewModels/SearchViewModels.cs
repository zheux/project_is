using System;
using System.Collections.Generic;

namespace GCRS.Services.ViewModels
{
    public class RentalSearchFilterVM
    {
        public string Keywords { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public string SelectedProvince { get; set; }

        public string SelectedMunicipality { get; set; }

        public string SelectedDistrict { get; set; }

        public string SelectedCategory { get; set; }

        public int? MinimumPrice { get; set; }

        public int? MaximumPrice { get; set; }

        public IList<bool> SelectedTag { get; set; }
    }

    public class RentalSearchVM
    {
        public RentalSearchFilterVM Filters;

        public IEnumerable<GCRS.Domain.RentalOffer> FilteredRentals;

        public IEnumerable<GCRS.Domain.Province> Provinces;
        public IEnumerable<GCRS.Domain.Municipality> Municipalities;
        public IEnumerable<GCRS.Domain.District> Districts;
        public IEnumerable<GCRS.Domain.Category> Categories;
        public IEnumerable<GCRS.Domain.Tag> Tags;
    }

    public class SellSearchFilterVM
    {
        public string Keywords { get; set; }

        public DateTime Date { get; set; }

        public string SelectedProvince { get; set; }

        public string SelectedMunicipality { get; set; }

        public string SelectedDistrict { get; set; }

        public string SelectedCategory { get; set; }

        public int? MinimumPrice { get; set; }

        public int? MaximumPrice { get; set; }

        public IList<bool> SelectedTag { get; set; }
    }

    public class SellSearchVM
    {
        public SellSearchFilterVM Filters;

        public IEnumerable<GCRS.Domain.SellOffer> FilteredSells;

        public IEnumerable<GCRS.Domain.Province> Provinces;     
        public IEnumerable<GCRS.Domain.Municipality> Municipalities;
        public IEnumerable<GCRS.Domain.District> Districts;
        public IEnumerable<GCRS.Domain.Category> Categories;
        public IEnumerable<GCRS.Domain.Tag> Tags;
    }
}