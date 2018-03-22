using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class SellOfferRepository : IOfferRepository<SellOffer>
    {
        public void AddOffer(SellOffer offer)
        {
            using (var context = new ApplicationDbContext())
            {
                if (offer != null)
                {
                    context.SellOffers.Add(offer);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveOffer(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var offer = context.SellOffers.SingleOrDefault(m => m.Id == id);
                if (offer != null)
                {
                    context.SellOffers.Remove(offer);
                    context.SaveChanges();
                }
            }
        }

        public SellOffer FindOffer(Func<SellOffer, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SellOffers.SingleOrDefault(predicate);
            }
        }

        public IEnumerable<SellOffer> GetOffers()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SellOffers.Include("Property")
                                        .Include("Property.Province")
                                        .Include("Property.Municipality")
                                        .Include("Property.District")
                                        .Include("Property.Category")
                                        .Include("Client")
                                        .Include("Agent")
                                        .ToList();
            }
        }
    }
}
