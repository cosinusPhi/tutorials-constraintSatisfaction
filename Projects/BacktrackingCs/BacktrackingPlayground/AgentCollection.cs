using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class AgentCollection<TIdentifier,TAgent> : ConcurrentDictionary<TIdentifier,TAgent> where TAgent : Agent, new()
    {
    
        public TAgent create(TIdentifier identifier)
        {
            TAgent agent = new TAgent();
            TryAdd(identifier, agent);
            return agent;
        }


        public AgentCollection<TIdentifier,TAgent> copy()
        {
            lock(this)
            { 
                return (AgentCollection<TIdentifier, TAgent>)this.MemberwiseClone();
            }
        }

    }
}
