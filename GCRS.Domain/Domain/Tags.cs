﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain.Domain
{
    public enum OfferType { Sell, Rental, All}

    public class Tags
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public OfferType OfferType { get; set; }
    }
}
