using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public enum OfferState { Published, Paid, Canceled};

    public class RentalOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public uint Comission { get; set; }
        public RentTimeUnit RTU { get; set; }
        public int PricePerRTU { get; set; }

        [ForeignKey ("Client")]
        public string ClientUserName { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey("Agent")]
        public string AgentUserName { get; set; }
        public Agent Agent { get; set; }

        public OfferState State { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class SellOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public uint Comission { get; set; }
        public int Price { get; set; }

        [ForeignKey("Client")]
        public string ClientUserName { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey("Agent")]
        public string AgentUserName { get; set; }
        public Agent Agent { get; set; }
        public OfferState State { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public bool IsDeleted { get; set; }
    }
}
