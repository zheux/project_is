using GCRS.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public enum State { Requested, Draft, Published, Paid, Canceled};

    public class RentalOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public uint Comission { get; set; }
        public RentTimeUnit RTU { get; set; }
        public int PricePerRTU { get; set; }

        public Client Client { get; set; }
        public Property Property { get; set; }
        public Agent Agent { get; set; }
        public State State { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }

    public class SellOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public uint Comission { get; set; }
        public int Price { get; set; }

        public Client Client { get; set; }
        public Property Property { get; set; }
        public Agent Agent { get; set; }
        public State State { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
