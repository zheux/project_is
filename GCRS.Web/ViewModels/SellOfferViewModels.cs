using System;
using System.Collections.Generic;

namespace GCRS.Web.ViewModels
{
    
    public class SellOfferViewModels
    {
        public GCRS.Domain.SellOffer Offer;

        public IEnumerable<GCRS.Domain.Agent> Agents;
        public IEnumerable<GCRS.Domain.Client> Clients;
        public IEnumerable<GCRS.Domain.Property> Properties;
        public IEnumerable<GCRS.Domain.Tag> Tags;   
    }
}