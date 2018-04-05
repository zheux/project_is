using System;
using System.Collections.Generic;

namespace GCRS.Web.ViewModels
{
    
    public class PropertyViewModels
    {
        public GCRS.Domain.Property Property;

        public IEnumerable<GCRS.Domain.Province> Provinces;
        public IEnumerable<GCRS.Domain.Municipality> Municipalities;
        public IEnumerable<GCRS.Domain.District> Districts;
        public IEnumerable<GCRS.Domain.Category> Categories;
    }
}