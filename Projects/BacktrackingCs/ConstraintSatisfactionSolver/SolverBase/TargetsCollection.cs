using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground
{
    public class TargetsCollection<T> : List<Target<T>> 
    {
        public bool AreAllMet(T subject)
        {         
            return this.AsParallel().Count(c => c.isMet(subject) == false) == 0;        
        }

        public Target<T> add()
        {
            Target<T> target = new Target<T>();
            base.Add(target);
            return target;
        }

    }
}
