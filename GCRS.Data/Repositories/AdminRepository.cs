using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public void AddAdmin(Admin admin)
        {
            using (var context = new ApplicationDbContext())
            {
                if (admin != null)
                {
                    context.Admins.Add(admin);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveAdmin(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var admin = context.Admins.SingleOrDefault(m => m.Username == username);
                if (admin != null)
                {
                    context.Admins.Remove(admin);
                    context.SaveChanges();
                }
            }
        }

        public Admin FindAdmin(Func<Admin, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Admins.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Admin> GetAdmins()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Admins.ToList();
            }
        }
    }
}
