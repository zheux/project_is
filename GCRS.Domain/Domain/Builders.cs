using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain.Domain
{
    public class Rental
    {
        public int Id { get; set; }

        public RentalOffer RentalOffer { get; set; }
        public Client Client { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Sell
    {
        public int Id { get; set; }

        public SellOffer RentalOffer { get; set; }
        public Client Client { get; set; }
        public DateTime Date{ get; set; }
    }
}
