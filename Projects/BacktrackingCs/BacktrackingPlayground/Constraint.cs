using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class Constraint<T>
    {
        protected String name = String.Empty;

        internal Func<T, bool> mustMeet;
        internal Func<T, bool> mustNotMeet;

        public Constraint<T> Caption(String name)
        {
            this.name = name;
            return this;
        }


        public Constraint<T> MustNotMeet(Func<T, bool> function)
        {
            this.mustNotMeet = function;
            return this;
        }

        public Constraint<T> MustMeet(Func<T, bool> function)
        {
            this.mustMeet = function;
            return this;
        }


        public bool isMet(T subject)
        {            
            bool result =  ((mustMeet!=null) ? mustMeet(subject) : true)
                && !((mustNotMeet!=null) ? mustNotMeet(subject) : false);

            Trace.WriteLine("Evaluated Constraint:" + name + " result=" + result);

            return result;
        }
    }
}
