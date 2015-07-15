using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground
{
    public class ConstraintsCollection<T> : List<Constraint<T>>  
    {
        public bool areAllMet(T subject)
        {
            return this.All(c => c!=null && c.isMet(subject) == true);
        }

        public Constraint<T> add()
        {
            Constraint<T> constraint = new Constraint<T>();
            base.Add(constraint);
            return constraint;
        }

    }
}
