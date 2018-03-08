using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IMunicipalityRepository
    {
        void AddMunicipality(Municipality municipality);
        void RemoveMunicipality(int id);
        Municipality FindMunicipality(Func<Municipality, bool> predicate);
        IEnumerable<Municipality> GetMunicipalities();
    }
}
