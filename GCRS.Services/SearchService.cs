using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;
using GCRS.Data;

namespace GCRS.Services
{
    public class SearchService: Abstract.ISearchService
    {
        private IUnitOfWork _unitOfWork;

        public SearchService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<RentalOffer> SearchRentalOffers(Func<RentalOffer, bool> cond)
        {
            return _unitOfWork.Repository<RentalOffer>()
                    .Include("RTU")
                    .Include("Property")
                    .Include("Property.Category")
                    .Include("Property.District")
                    .Include("Property.Municipality")
                    .Include("Property.Province")
                    .Where(m => m.State == State.Published)
                    .Where(cond)
                    .ToList();
        }
    }
}
