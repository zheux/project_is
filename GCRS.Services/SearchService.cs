using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;
using GCRS.Data.Repositories;

namespace GCRS.Services
{
    public class SearchService
    {
        private RentalOfferRepository _rentalOfferRepo;
        private SellOfferRepository _sellOfferRepo;

        public SearchService()
        {
            _rentalOfferRepo = new RentalOfferRepository();
            _sellOfferRepo = new SellOfferRepository();
        }

        public IEnumerable<RentalOffer> SearchRentalOffers(Func<RentalOffer, bool> cond)
        {
            return _rentalOfferRepo.GetOffers()
                    .Where(m => m.State == State.Published)
                    .Where(cond)
                    .ToList();
        }
    }
}
