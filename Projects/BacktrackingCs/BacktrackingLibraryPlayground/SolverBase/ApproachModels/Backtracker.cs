using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.SolverBase.ApproachModels
{
    public class Backtracker<TAgent> : IApproachModel<TAgent>
    {
        protected List<TAgent> approach;
        protected TAgent solution;
        protected SolverBase<TAgent> solverBase;

        public int MaximumRecursionDepth { get; set; }
        public bool FoundSolution { get; private set; }

        public Backtracker(SolverBase<TAgent> solverBase)
        {
            this.solverBase = solverBase;
            approach = new List<TAgent>();
        }

        protected eBacktrackingIterationResult solve(TAgent agent, int recursionDepth)
        {
            Trace.WriteLine("Level:" + recursionDepth);
            if (recursionDepth > MaximumRecursionDepth)
            {
                return eBacktrackingIterationResult.EXCEEDED_MAX_DEPTH;
            }

            if (solverBase.Targets.AreAllMet(agent))
            {
                Trace.WriteLine("Found solution:" + agent.ToString());
                approach.Add(agent);
                return eBacktrackingIterationResult.FOUND_SOLUTION;
            }
            else {
                List<TAgent> nextAgents = solverBase.Actions.getNext(agent);
                IEnumerable<TAgent> validNextAgents = nextAgents.Where( agentItem => solverBase.Constraints.areAllMet(agentItem));


                Trace.WriteLine("Total Nexts: " + nextAgents.Count() + " Valid nexts: " + validNextAgents.Count());

                if (validNextAgents.Count() == 0)
                {
                    Trace.WriteLine("Deadend");
                    return eBacktrackingIterationResult.DEADEND;
                }
                else
                {
                    eBacktrackingIterationResult result = eBacktrackingIterationResult.CONTINUE;

                    foreach( TAgent agentItem in validNextAgents)
                    {
                        if (solve(agentItem, (recursionDepth + 1)) == eBacktrackingIterationResult.FOUND_SOLUTION)
                        {
                            Trace.WriteLine("Child reported solution!");
                            approach.Add(agent);
                            result = eBacktrackingIterationResult.FOUND_SOLUTION;
                            return result;
                        }
                    }

                    return result;
                }

            }
            
        }

        public bool solve(TAgent start)
        {
            solve(start, 0);
            return true;
        }

        public TAgent getSolution()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgent> getApproach()
        {
            return approach;
        }
    }

    public enum eBacktrackingIterationResult
    {
        CONTINUE,
        FOUND_SOLUTION,
        EXCEEDED_MAX_DEPTH,
        INVALID_STEP,
        DEADEND
    }
}
