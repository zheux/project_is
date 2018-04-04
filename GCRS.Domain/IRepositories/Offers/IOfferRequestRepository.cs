using System;
using System.Collections.Generic;

namespace GCRS.Domain
{
    public interface IOfferRequestRepository
    {
        void AddOfferRequest(OfferRequest offer);
        void RemoveOfferRequest(int id);
        OfferRequest FindOfferRequest(Func<OfferRequest, bool> predicate);
        IEnumerable<OfferRequest> GetOfferRequests();
    }
}
