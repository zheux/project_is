using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IProvinceRepository
    {
        void AddProvince(Province province);
        void RemoveProvince(string name);
        Province FindProvince(Func<Province, bool> predicate);
        IEnumerable<Province> GetProvinces();
    }
}
