using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class ActionCollection<TAgentCollection> : List<Action<TAgentCollection>>
    {
        public ActionCollection()
        {
        }

        public Action<TAgentCollection> @add()
        {
            Action<TAgentCollection> action = new Action<TAgentCollection>();
            base.Add(action);
            return action;
        }

        public List<TAgentCollection> getNext(TAgentCollection subject)
        {
            List<TAgentCollection> tAgentCollections = new List<TAgentCollection>();
            this.AsParallel<Action<TAgentCollection>>().ForAll<Action<TAgentCollection>>((Action<TAgentCollection> action) => tAgentCollections.AddRange(action.Function(subject)));
            return tAgentCollections;
        }
    }
}
