using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    class ClientRepository : IClientRepository
    {
        public void AddClient(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                if (client != null)
                {
                    context.Clients.Add(client);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveClient(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var client = context.Clients.SingleOrDefault(m => m.Username == username);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
            }
        }

        public Client FindClient(Func<Client, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Client> GetClients()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients;
            }
        }
    }
}
