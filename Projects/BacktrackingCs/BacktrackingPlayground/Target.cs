using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class Target<T> //where T:class 
    {
        internal Func<T, bool> condition;
        
        public Target<T> conditionIs(Func<T, bool> condition)
        {
            this.condition = condition;
            return this;
        }

        public bool isMet(T subject)
        {
            bool result = ((condition != null) ? condition(subject) : true);

            Trace.WriteLine("Evaluated Target. result=" + result);
            return result;
        }

    }
}
