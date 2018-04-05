using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCRS.Domain
{
    public enum RequestState { Requested, Draft, Canceled };

    public class OfferRequest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public string ClientUsername { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Agent")]
        public string AgentUsername{ get; set; }
        public Agent Agent { get; set; }

        public RequestState State { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public DateTime RequestedDate { get; set; }

        public bool isDeleted { get; set; }
    }
}
