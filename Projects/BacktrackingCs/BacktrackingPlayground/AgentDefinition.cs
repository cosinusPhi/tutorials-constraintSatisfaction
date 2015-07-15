using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class AgentDefinition : Agent
    { 
        public eAgentStates State { get; set; }
    }

    public enum eAgentName
    {
        NOBODY,
        FARMER,
        WOLF,
        SHEEP,
        KALE
    }

    public enum eAgentStates
    {
        RIGHT_BANK,
        LEFT_BANK,
        IN_TRANSIT
    }

}
