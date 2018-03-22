using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCRS.Domain
{
    public class Reservation
    {
        [Key, Column(Order = 0), ForeignKey("RentalOffer")]
        public int RentalOfferId { get; set; }
        public RentalOffer RentalOffer { get; set; }

        [Key, Column(Order = 1), ForeignKey("Client")]
        public string ClientUsername { get; set; }
        public Client Client { get; set; }

        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
