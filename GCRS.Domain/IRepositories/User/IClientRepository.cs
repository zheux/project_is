using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void RemoveClient(string username);
        Client FindClient(Func<Client, bool> predicate);
        IEnumerable<Client> GetClients();
    }
}
