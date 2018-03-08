using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class RentalOfferRepository : IOfferRepository<RentalOffer>
    {
        public void AddOffer(RentalOffer offer)
        {
            using (var context = new ApplicationDbContext())
            {
                if (offer != null)
                {
                    context.RentalOffers.Add(offer);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveOffer(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var offer = context.RentalOffers.SingleOrDefault(m => m.Id == id);
                if (offer != null)
                {
                    context.RentalOffers.Remove(offer);
                    context.SaveChanges();
                }
            }
        }

        public RentalOffer FindOffer(Func<RentalOffer, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.RentalOffers.SingleOrDefault(predicate);
            }
        }

        public IEnumerable<RentalOffer> GetOffers()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.RentalOffers.Include("RTU")
                                            .Include("Property")
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
