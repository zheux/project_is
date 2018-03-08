﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public class Agent:User
    {
        public ICollection<SellOffer> SellDraftList { get; set; }
        public ICollection<RentalOffer> RentalDraftList { get; set; }
    }
}
