using BacktrackingLibraryPlayground.SolverBase;
using BacktrackingLibraryPlayground.SolverBase.ApproachModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingLibraryPlayground.WolfKaleSheep
{
    public class WolfKaleSheepProblem
    {
        public SolverBase<WolfKaleSheepAgentModel> SolverBase { get; set; }

        protected ConstraintsCollection<WolfKaleSheepAgentModel> buildConstraints()
        {
            var constraints = new ConstraintsCollection<WolfKaleSheepAgentModel>();

            constraints.add()
               .Caption("Wolf_Eats_Sheep")
               .MustNotMeet((subject) =>
               {
                   eAgentStates stateOfSheep = subject.Agents[eAgentName.SHEEP].State;
                   eAgentStates stateOfFarmer = subject.Agents[eAgentName.FARMER].State;
                   eAgentStates stateOfWolf = subject.Agents[eAgentName.WOLF].State;
                   return ((stateOfSheep == stateOfWolf) && stateOfFarmer != stateOfWolf);
               });

            constraints.add()
              .Caption("Sheep_Eats_Kale")
              .MustNotMeet((subject) =>
              {
                  eAgentStates stateOfSheep = subject.Agents[eAgentName.SHEEP].State;
                  eAgentStates stateOfFarmer = subject.Agents[eAgentName.FARMER].State;
                  eAgentStates stateOfKale = subject.Agents[eAgentName.KALE].State;
                  return ((stateOfSheep == stateOfKale) && stateOfFarmer != stateOfSheep);
              });

            return constraints;
        }

        private TargetsCollection<WolfKaleSheepAgentModel> buildTargets()
        {
            var targets = new TargetsCollection<WolfKaleSheepAgentModel>();

            targets.add().conditionIs((subject) =>
            {
                return (subject.Agents.Where(agent => agent.Key != eAgentName.NOBODY)
                    .Count(a => a.Value.State != eAgentStates.LEFT_BANK) == 0);
            });

            return targets;
        }

        public WolfKaleSheepProblem()
        {
            SolverBase = new SolverBase<WolfKaleSheepAgentModel>()
            {
                Constraints = buildConstraints(),
                Targets = buildTargets(),
                Actions = buildActions()
            };

            // todo IOC
            SolverBase.ApproachModel = new Backtracker<WolfKaleSheepAgentModel>(SolverBase)
            {
                MaximumRecursionDepth = 8
            };

        }

        private ActionCollection<WolfKaleSheepAgentModel> buildActions()
        {
            var result = new ActionCollection<WolfKaleSheepAgentModel>();

            result.Add(new NextMoveAction());

            return result;
        }
    }

}
