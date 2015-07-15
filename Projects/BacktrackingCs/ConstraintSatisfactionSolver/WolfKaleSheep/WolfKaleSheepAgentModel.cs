using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace BacktrackingLibraryPlayground.WolfKaleSheep
{
    public class WolfKaleSheepAgentModel : AgentModelBase<AgentDefinition, eAgentName>, ICloneable
    {
        public WolfKaleSheepAgentModel()
        {
            create(eAgentName.FARMER).State = eAgentStates.RIGHT_BANK;
            create(eAgentName.WOLF).State = eAgentStates.RIGHT_BANK;
            create(eAgentName.SHEEP).State = eAgentStates.RIGHT_BANK;
            create(eAgentName.KALE).State = eAgentStates.RIGHT_BANK;
            create(eAgentName.NOBODY).State = eAgentStates.RIGHT_BANK;          
        }


        public object Clone()
        {
            WolfKaleSheepAgentModel result = new WolfKaleSheepAgentModel()
            {
                Agents = new ConcurrentDictionary<eAgentName,AgentDefinition>()
            };

            foreach( KeyValuePair<eAgentName,AgentDefinition> agent in Agents)
            {
                 result.Agents.TryAdd(agent.Key, (AgentDefinition) agent.Value.Clone());
            }
            /*
            Agents.AsParallel().ForAll(agent =>
                result.Agents.TryAdd(agent.Key, (AgentDefinition) agent.Value.Clone()));
            */
            return result;
        }
    }

    public class AgentDefinition : ICloneable
    {
        public eAgentName Name { get; set; }
        public eAgentStates State { get; set; }
        

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public enum eAgentStates
    {
        RIGHT_BANK,
        LEFT_BANK,
        IN_TRANSIT
    }

    public enum eAgentName
    {
        NOBODY,
        FARMER,
        WOLF,
        SHEEP,
        KALE
    }


}
