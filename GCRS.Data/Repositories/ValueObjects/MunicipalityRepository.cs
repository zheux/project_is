using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        public void AddMunicipality(Municipality municipality)
        {
            using (var context = new ApplicationDbContext())
            {
                if (municipality != null)
                {
                    context.Municipalities.Add(municipality);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveMunicipality(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var municipality = context.Municipalities.SingleOrDefault(m => m.Id == id);
                if (municipality != null)
                {
                    context.Municipalities.Remove(municipality);
                    context.SaveChanges();
                }
            }
        }

        public Municipality FindMunicipality(Func<Municipality, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Municipalities.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Municipality> GetMunicipalities()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Municipalities.ToList();
            }
        }
    }
}
