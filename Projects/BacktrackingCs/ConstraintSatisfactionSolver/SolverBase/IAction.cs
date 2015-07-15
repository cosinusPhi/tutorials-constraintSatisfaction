using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.SolverBase
{
    public interface IAction<T>
    {
        String Title { get; }
        IEnumerable<T> getNext(T current);
    }
}
