using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void RemoveCategory(string name);
        Category FindCategory(Func<Category, bool> predicate);
        IEnumerable<Category> GetCategories();
    }
}
