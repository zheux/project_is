using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCRS.Domain
{
    public class Purchase
    {
        [Key, Column(Order = 0), ForeignKey("SellOffer")]
        public int SellOfferId { get; set; }
        public SellOffer SellOffer { get; set; }

        [Key, Column(Order = 1), ForeignKey("Client")]
        public string ClientUsername{ get; set; }
        public Client Client { get; set; }

        public DateTime PurchaseDate{ get; set; }
    }
}
