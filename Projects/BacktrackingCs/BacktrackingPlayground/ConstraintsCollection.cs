using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class ConstraintsCollection<T> : List<Constraint<T>>
    {
        public bool areAllMet(T subject)
        {
            return this.AsParallel().Count(c => c.isMet(subject) == false) == 0;
        }

        public Constraint<T> add()
        {
            Constraint<T> constraint = new Constraint<T>();
            base.Add(constraint);
            return constraint;
        }

    }
}
