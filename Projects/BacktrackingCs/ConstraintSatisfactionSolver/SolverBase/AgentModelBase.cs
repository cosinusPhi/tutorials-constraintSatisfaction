using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground
{
    public class AgentModelBase<TAgent, TAgentIdentifier> where TAgent: ICloneable, new()
    {
        public ConcurrentDictionary<TAgentIdentifier, TAgent> Agents { get; protected set; }

        public AgentModelBase()
        {
            Agents = new ConcurrentDictionary<TAgentIdentifier, TAgent>();
        }

        public TAgent create(TAgentIdentifier identifier)
        {
            TAgent agent = new TAgent();
            Agents.TryAdd(identifier, agent);
            return agent;
        }
    }
}
