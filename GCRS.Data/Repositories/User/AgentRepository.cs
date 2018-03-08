using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        public void AddAgent(Agent agent)
        {
            using (var context = new ApplicationDbContext())
            {
                if (agent != null)
                {
                    context.Agents.Add(agent);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveAgent(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var agent = context.Agents.SingleOrDefault(m => m.Username == username);
                if (agent != null)
                {
                    context.Agents.Remove(agent);
                    context.SaveChanges();
                }
            }
        }

        public Agent FindAgent(Func<Agent, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Agents.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Agent> GetAgents()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Agents.ToList();
            }
        }
    }
}
