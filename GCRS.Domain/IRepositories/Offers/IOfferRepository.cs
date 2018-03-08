using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IOfferRepository<T>
    {
        void AddOffer(T offer);
        void RemoveOffer(int id);
        T FindOffer(Func<T, bool> predicate);
        IEnumerable<T> GetOffers();
    }
}
