using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.SolverBase.ApproachModels
{
    public interface IApproachModel<TAgent>
    {
        bool solve(TAgent start);
        TAgent getSolution();
        IEnumerable<TAgent> getApproach();
    }
}
