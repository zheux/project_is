﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GCRS.Web.ViewModels
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

        public int MinimumPrice { get; set; }

        public int MaximumPrice { get; set; }
    }

    public class RentalSearchVM
    {
        public RentalSearchFilterVM Filters;

        public IEnumerable<GCRS.Domain.Rental> FilteredRentals;

        public IEnumerable<GCRS.Domain.Province> Provinces;
        public IEnumerable<GCRS.Domain.Municipality> Municipalities;
        public IEnumerable<GCRS.Domain.District> Districts;
        public IEnumerable<GCRS.Domain.Category> Categories;
    }
}