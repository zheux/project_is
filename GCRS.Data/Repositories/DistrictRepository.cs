using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        public void AddDistrict(District district)
        {
            using (var context = new ApplicationDbContext())
            {
                if (district != null)
                {
                    context.Districts.Add(district);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveDistrict(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var district = context.Districts.SingleOrDefault(m => m.Id == id);
                if (district != null)
                {
                    context.Districts.Remove(district);
                    context.SaveChanges();
                }
            }
        }

        public District FindDistrict(Func<District, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Districts.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<District> GetDistricts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Districts.ToList();
            }
        }
    }
}
