using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public abstract class BacktrackableBase<AgentType, AgentIdentifier> where AgentType : Agent, new()
    {
        public AgentCollection<AgentIdentifier, AgentType> Agents = new AgentCollection<AgentIdentifier,AgentType>();
        public ConstraintsCollection<BacktrackableBase<AgentType, AgentIdentifier>> Constraints = new ConstraintsCollection<BacktrackableBase<AgentType,AgentIdentifier>>();
        public TargetsCollection<BacktrackableBase<AgentType, AgentIdentifier>> Targets = new TargetsCollection<BacktrackableBase<AgentType,AgentIdentifier>>();
        public ActionCollection<AgentCollection<AgentIdentifier, AgentType>> Actions = new ActionCollection<AgentCollection<AgentIdentifier, AgentType>>();
       
    }
}
