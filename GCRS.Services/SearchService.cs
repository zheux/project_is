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
        private ReservationRepository _reservationRepository;
        private PurchaseRepository _purchaseRepository;

        public SearchService()
        {
            _rentalOfferRepo = new RentalOfferRepository();
            _sellOfferRepo = new SellOfferRepository();
            _reservationRepository = new ReservationRepository();
            _purchaseRepository = new PurchaseRepository();
        }

        public IEnumerable<RentalOffer> SearchRentalOffers(ViewModels.RentalSearchFilterVM filters)
        {
            Func<RentalOffer, bool> cond;
            if (filters != null)
            {
                cond = m =>
                {
                    bool ret = true;
                    if (filters.MaximumPrice < filters.MinimumPrice || m.PricePerRTU > filters.MaximumPrice || filters.MinimumPrice > m.PricePerRTU)
                        ret = false;
                    if (filters.MaximumPrice == 0 && filters.MinimumPrice == 0)
                        ret = true;
                    if (filters.Keywords != null && !m.Title.Split().Contains(filters.Keywords))
                        ret = false;
                    if (filters.SelectedCategory != null && (m.Property.Category == null || m.Property.Category.Name != filters.SelectedCategory))
                        ret = false;
                    if (filters.SelectedProvince != null && (m.Property.Province == null || m.Property.Province.Name != filters.SelectedProvince))
                        ret = false;
                    if (filters.SelectedDistrict != null && (m.Property.District == null || m.Property.District.Name != filters.SelectedDistrict))
                        ret = false;
                    if (filters.SelectedMunicipality != null && (m.Property.Municipality == null || m.Property.Municipality.Name != filters.SelectedMunicipality))
                        ret = false;
                    foreach (var reservation in _reservationRepository.GetReservations()
                        .Where(t => t.RentalOfferId == m.Id))
                    {
                        if (filters.ArrivalDate < reservation.DepartureDate && filters.DepartureDate > reservation.ArrivalDate)
                            ret = false;
                        if (reservation.ArrivalDate < filters.DepartureDate && reservation.DepartureDate > filters.ArrivalDate)
                            ret = false;
                    }
                    return ret;
                };
            }
            else
                cond = m => m.Id != -1;
            return _rentalOfferRepo.GetOffers()
                    .Where(m => m.State == State.Published)
                    .Where(cond)
                    .ToList();
        }

        public IEnumerable<SellOffer> SearchSellOffers(ViewModels.SellSearchFilterVM filters)
        {
            Func<SellOffer, bool> cond;
            if (filters != null)
            {
                cond = m =>
                {
                    bool ret = true;
                    if (filters.MaximumPrice < filters.MinimumPrice || m.Price > filters.MaximumPrice || filters.MinimumPrice > m.Price)
                        ret = false;
                    if (filters.MaximumPrice == 0 && filters.MinimumPrice == 0)
                        ret = true;
                    if (filters.Keywords != null && !m.Title.Split().Contains(filters.Keywords))
                        ret = false;
                    if (filters.SelectedCategory != null && (m.Property.Category == null || m.Property.Category.Name != filters.SelectedCategory))
                        ret = false;
                    if (filters.SelectedProvince != null && (m.Property.Province == null || m.Property.Province.Name != filters.SelectedProvince))
                        ret = false;
                    if (filters.SelectedDistrict != null && (m.Property.District == null || m.Property.District.Name != filters.SelectedDistrict))
                        ret = false;
                    if (filters.SelectedMunicipality != null && (m.Property.Municipality == null || m.Property.Municipality.Name != filters.SelectedMunicipality))
                        ret = false;
                    return ret;
                };
            }
            else
                cond = m => m.Id != -1;
            return _sellOfferRepo.GetOffers()
                    .Where(m => m.State == State.Published)
                    .Where(cond)
                    .ToList();
        }
    }
}
