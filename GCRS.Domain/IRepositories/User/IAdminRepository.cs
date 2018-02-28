using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        void RemoveAdmin(string username);
        Admin FindAdmin(Func<Admin, bool> predicate);
        IEnumerable<Admin> GetAdmins();
    }
}
