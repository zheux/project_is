using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IDistrictRepository
    {
        void AddDistrict(District district);
        void RemoveDistrict(int id);
        District FindDistrict(Func<District, bool> predicate);
        IEnumerable<District> GetDistricts();
    }
}
