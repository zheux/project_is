using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class OfferRequestRepository : IOfferRequestRepository
    {
        public void AddOfferRequest(OfferRequest offerRequest)
        {
            using (var context = new ApplicationDbContext())
            {
                if (offerRequest != null)
                {
                    context.OfferRequests.Add(offerRequest);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveOfferRequest(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var offerRequest = context.OfferRequests.SingleOrDefault(m => m.Id == id);
                if (offerRequest != null)
                {
                    context.OfferRequests.Remove(offerRequest);
                    context.SaveChanges();
                }
            }
        }

        public OfferRequest FindOfferRequest(Func<OfferRequest, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.OfferRequests.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<OfferRequest> GetOfferRequests()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.OfferRequests.ToList();
            }
        }
    }
}
