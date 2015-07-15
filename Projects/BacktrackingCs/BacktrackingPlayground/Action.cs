using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class Action<TAgentCollection>
    {
        internal Func<TAgentCollection,List<TAgentCollection>> Function { get; set; }
        public String Title { get; set; }

    }
}
