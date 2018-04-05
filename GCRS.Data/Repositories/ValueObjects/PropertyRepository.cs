using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public void AddProperty(Property Property)
        {
            using (var context = new ApplicationDbContext())
            {
                if (Property != null)
                {
                    context.Properties.Add(Property);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveProperty(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var Property = context.Properties.SingleOrDefault(m => m.Id == id);
                if (Property != null)
                {
                    context.Properties.Remove(Property);
                    context.SaveChanges();
                }
            }
        }

        public Property FindProperty(Func<Property, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Properties.SingleOrDefault(predicate);
            }
        }

        public IEnumerable<Property> GetProperties()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Properties.Include("Category")
                                         .Include("Province")
                                         .Include("District")
                                         .Include("Municipality")
                                         .ToList();
            }
        }
    }
}
