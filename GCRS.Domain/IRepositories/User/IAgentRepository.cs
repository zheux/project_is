using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public interface IAgentRepository
    {
        void AddAgent(Agent agent);
        void RemoveAgent(string username);
        Agent FindAgent(Func<Agent, bool> predicate);
        IEnumerable<Agent> GetAgents();
    }
}
