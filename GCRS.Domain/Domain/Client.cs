using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public class Client:User
    {
        public ICollection<SellOffer> SellRequestList { get; set; }
        public ICollection<RentalOffer> RentalRequestList { get; set; }
        
    }
}
