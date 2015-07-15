using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.SolverBase
{
    public class ActionCollection<TAgentModel> : List<IAction<TAgentModel>>
    {
        public ActionCollection()
        {
        }

        public IAction<TAgentModel> add(IAction<TAgentModel> action)
        {
            base.Add(action);
            return action;
        }

        public List<TAgentModel> getNext(TAgentModel subject)
        {
            var result = new List<TAgentModel>();
            this.AsParallel().ForAll(act => result.AddRange(act.getNext(subject)));
            return result;
        }
    }
}
