using BacktrackingLibraryPlayground.SolverBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.WolfKaleSheep
{
    public class NextMoveAction : IAction<WolfKaleSheepAgentModel>
    {

        public string Title
        {
            get
            {
                return "GetNextMove";
            }
        }

        public IEnumerable<WolfKaleSheepAgentModel> getNext(WolfKaleSheepAgentModel current)
        {
            var result = new List<WolfKaleSheepAgentModel>();

            current.Agents
                .AsParallel()
                .Where(kvp=> kvp.Key != eAgentName.FARMER)
                .Where(kvp => kvp.Value.State == current.Agents[eAgentName.FARMER].State || kvp.Key == eAgentName.NOBODY)
                .ForAll(agentToMove =>
                {
                    var next = (WolfKaleSheepAgentModel) current.Clone();
                    eAgentStates nextState = current.Agents[eAgentName.FARMER].State == eAgentStates.LEFT_BANK ? 
                        eAgentStates.RIGHT_BANK : eAgentStates.LEFT_BANK;
                    next.Agents[eAgentName.FARMER].State = nextState;
                    next.Agents[agentToMove.Key].State = nextState;
                    result.Add(next);
                });

            return result;
        }


    }
}
