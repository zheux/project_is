using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category)
        {
            using (var context = new ApplicationDbContext())
            {
                if (category != null)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveCategory(string name)
        {
            using (var context = new ApplicationDbContext())
            {
                var category = context.Categories.SingleOrDefault(m => m.Name == name);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }

        public Category FindCategory(Func<Category, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Categories.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Category> GetCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
