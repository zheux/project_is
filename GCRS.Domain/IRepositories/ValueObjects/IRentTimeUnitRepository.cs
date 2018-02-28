using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IRentTimeUnitRepository
    {
        void AddRentTimeUnit(RentTimeUnit rentTimeUnit);
        void RemoveRentTimeUnit(string name);
        RentTimeUnit FindRentTimeUnit(Func<RentTimeUnit, bool> predicate);
        IEnumerable<RentTimeUnit> GetRentTimeUnits();
    }
}
