using BacktrackingLibraryPlayground.SolverBase;
using BacktrackingLibraryPlayground.SolverBase.ApproachModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground
{
    public class SolverBase<TAgentModel>
    {
        public ConstraintsCollection<TAgentModel> Constraints { get; set; }
        public TargetsCollection<TAgentModel> Targets { get; set; }
        public ActionCollection<TAgentModel> Actions { get; set; }
        public IApproachModel<TAgentModel> ApproachModel { get; set; }
        
        public SolverBase()
        {
            Constraints = new ConstraintsCollection<TAgentModel>();
            Targets = new TargetsCollection<TAgentModel>();
        }
    }

}
