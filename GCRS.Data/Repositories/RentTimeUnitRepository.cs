using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class RentTimeUnitRepository : IRentTimeUnitRepository
    {
        public void AddRentTimeUnit(RentTimeUnit unit)
        {
            using (var context = new ApplicationDbContext())
            {
                if (unit != null)
                {
                    context.RentTimeUnits.Add(unit);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveRentTimeUnit(string name)
        {
            using (var context = new ApplicationDbContext())
            {
                var unit = context.RentTimeUnits.SingleOrDefault(m => m.Name == name);
                if (unit != null)
                {
                    context.RentTimeUnits.Remove(unit);
                    context.SaveChanges();
                }
            }
        }

        public RentTimeUnit FindRentTimeUnit(Func<RentTimeUnit, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.RentTimeUnits.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<RentTimeUnit> GetRentTimeUnits()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.RentTimeUnits.ToList();
            }
        }
    }
}
