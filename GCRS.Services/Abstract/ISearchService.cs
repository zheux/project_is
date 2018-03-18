using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Services.Abstract
{
    public interface ISearchService
    {
        IEnumerable<RentalOffer> SearchRentalOffers(Func<RentalOffer, bool> cond);
    }
}
