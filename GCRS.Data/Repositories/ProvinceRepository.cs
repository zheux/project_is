using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        public void AddProvince(Province province)
        {
            using (var context = new ApplicationDbContext())
            {
                if (province != null)
                {
                    context.Provinces.Add(province);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveProvince(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var Province = context.Provinces.SingleOrDefault(m => m.Id == id);
                if (Province != null)
                {
                    context.Provinces.Remove(Province);
                    context.SaveChanges();
                }
            }
        }

        public Province FindProvince(Func<Province, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Provinces.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Province> GetProvinces()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Provinces.ToList();
            }
        }
    }
}
