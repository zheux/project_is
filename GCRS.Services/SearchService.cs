using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Services
{
    public class SearchService
    {
        private IUnitOfWork unitOfWork;

        public SearchService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public IEnumerable<RentalOffer> SearchRentalOffers(ViewModels.RentalSearchFilterVM filters, IList<Tag> TagList)
        {
            List<Reservation> Reservations = unitOfWork.Repository<Reservation>().ToList();
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
                    foreach (var reservation in Reservations
                                                    .Where(t => t.RentalOfferId == m.Id))
                    {
                        if (filters.ArrivalDate < reservation.DepartureDate && filters.DepartureDate > reservation.ArrivalDate)
                            ret = false;
                        if (reservation.ArrivalDate < filters.DepartureDate && reservation.DepartureDate > filters.ArrivalDate)
                            ret = false;
                    }
                    for (int i = 0; i < filters.SelectedTag.Count(); i++)
                    {
                        if (filters.SelectedTag[i] && m.Tags.SingleOrDefault(t => t.Name == TagList[i].Name) == null)
                            ret = false;
                    }
                    return ret;
                };
            }
            else
                cond = m => m.Id != -1;
            return unitOfWork.Repository<RentalOffer>()
                    .Include("RTU")
                    .Include("Property")
                    .Include("Property.Category")
                    .Include("Property.District")
                    .Include("Property.Municipality")
                    .Include("Property.Province")
                    .Include("Tags")
                    .Where(m => m.State == OfferState.Published)
                    .Where(cond)
                    .ToList();
        }
        
        public IEnumerable<SellOffer> SearchSellOffers(ViewModels.SellSearchFilterVM filters, IList<Tag> TagList)
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
                    for (int i = 0; i < filters.SelectedTag.Count(); i++)
                    {
                        if (filters.SelectedTag[i] && m.Tags.SingleOrDefault(t => t.Name == TagList[i].Name) == null)
                            ret = false;
                    }
                    return ret;
                };
            }
            else
                cond = m => m.Id != -1;
            return unitOfWork.Repository<SellOffer>()
                    .Include("Property")
                    .Include("Property.Category")
                    .Include("Property.District")
                    .Include("Property.Municipality")
                    .Include("Property.Province")
                    .Include("Tags")
                    .Where(m => m.State == OfferState.Published)
                    .Where(cond)
                    .ToList();
        }
    }
}
