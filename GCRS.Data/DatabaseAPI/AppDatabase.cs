using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data
{
    public static class AppDatabase
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        #region ADD
        public static void AddProvince(Province p)
        {
            if (p != null)
            {
                context.Provinces.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddMunicipality(Municipality p)
        {
            if (p != null)
            {
                context.Municipalities.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddDistrict(District p)
        {
            if (p != null)
            {
                context.Districts.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddCategory(Category p)
        {
            if (p != null)
            {
                context.Categories.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddRentTimeUnit(RentTimeUnit p)
        {
            if (p != null)
            {
                context.RentTimeUnits.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddAdmin(Admin p)
        {
            if (p != null)
            {
                context.Admins.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddClient(Client p)
        {
            if (p != null)
            {
                context.Clients.Add(p);
                context.SaveChanges();
            }
        }
        
        public static void AddAgent(Agent p)
        {
            if (p != null)
            {
                context.Agents.Add(p);
                context.SaveChanges();
            }
        }
        #endregion

        #region REMOVE
        public static void RemoveProvince(int id)
        {
            if (context.Provinces.Find(id) != null)
            {
                context.Provinces.Remove(context.Provinces.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveMunicipality(int id)
        {
            if (context.Municipalities.Find(id) != null)
            {
                context.Municipalities.Remove(context.Municipalities.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveDistrict(int id)
        {
            if (context.Districts.Find(id) != null)
            {
                context.Districts.Remove(context.Districts.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveCategory(int id)
        {
            if (context.Categories.Find(id) != null)
            {
                context.Categories.Remove(context.Categories.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveRentTimeUnit(int id)
        {
            if (context.RentTimeUnits.Find(id) != null)
            {
                context.RentTimeUnits.Remove(context.RentTimeUnits.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveUser(string username)
        {
            var user = context.Admins.SingleOrDefault(m => m.Username == username);
            if (user != null)
            {
                context.Admins.Remove(user);
                context.SaveChanges();
            }
        }
        #endregion

        #region FIND
        public static Client FindClient(string username)
        {
            Client cliente = context.Clients.SingleOrDefault(m => m.Username == username);
            return cliente;
        }

        public static Admin FindAdmin(string username)
        {
            Admin admin = context.Admins.SingleOrDefault(m => m.Username == username);
            return admin;
        }

        public static Agent FindAgent(string username)
        {
            Agent agent = context.Agents.SingleOrDefault(m => m.Username == username);
            return agent;
        }
        #endregion

        #region LIST
        public static List<Province> GetProvinces()
        {
            return context.Provinces.OrderBy(m => m.Name).ToList();
        }


        public static List<Municipality> GetMunicipalities()
        {
            return context.Municipalities.OrderBy(m => m.Name).ToList();
        }


        public static List<District> GetDistricts()
        {
            return context.Districts.OrderBy(m => m.Name).ToList();
        }


        public static List<Category> GetCategories()
        {
            return context.Categories.OrderBy(m => m.Name).ToList();
        }


        public static List<RentTimeUnit> GetRentTimeUnits()
        {
            return context.RentTimeUnits.OrderBy(m => m.Name).ToList();
        }

        public static List<Admin> GetAdmins()
        {
            return context.Admins.OrderBy(m => m.Username).ToList();
        }
        
        public static List<Client> GetClients()
        {
            return context.Clients.OrderBy(m => m.Username).ToList();
        }

        public static List<Agent> GetAgents()
        {
            return context.Agents.OrderBy(m => m.Username).ToList();
        }
        #endregion
    }
}
