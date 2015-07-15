using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingPlayground
{
    public class WolfKaleSheep : BacktrackableBase<AgentDefinition, eAgentName>
    {

        public WolfKaleSheep()
        {
            Agents.create(eAgentName.FARMER);
            Agents.create(eAgentName.WOLF);
            Agents.create(eAgentName.SHEEP);
            Agents.create(eAgentName.KALE);
            Agents.create(eAgentName.NOBODY);
            Agents.Values.AsParallel().ForAll(agent => agent.State = eAgentStates.RIGHT_BANK);


            Constraints.add()
                .Caption("Boat_Max_Capacity")
                .MustMeet((subject) =>
                {
                    return (subject.Agents.Count(a => a.Value.State == eAgentStates.IN_TRANSIT)) <= 2;
                });

            Constraints.add()
               .Caption("Wolf_Eats_Sheep")
               .MustNotMeet((subject) =>
               {
                   eAgentStates stateOfSheep = subject.Agents[eAgentName.SHEEP].State;
                   eAgentStates stateOfFarmer = subject.Agents[eAgentName.FARMER].State;
                   eAgentStates stateOfWolf = subject.Agents[eAgentName.WOLF].State;
                   return ((stateOfSheep == stateOfWolf) && stateOfFarmer != stateOfWolf);
               });

            Constraints.add()
              .Caption("Sheep_Eats_Kale")
              .MustNotMeet((subject) =>
              {
                  eAgentStates stateOfSheep = subject.Agents[eAgentName.SHEEP].State;
                  eAgentStates stateOfFarmer = subject.Agents[eAgentName.FARMER].State;
                  eAgentStates stateOfKale = subject.Agents[eAgentName.KALE].State;
                  return ((stateOfSheep == stateOfKale) && stateOfFarmer != stateOfSheep);
              });

            Actions.add().Function = (subject) =>
            {
                var result = new List<AgentCollection<eAgentName, AgentDefinition>>();
                subject 
                    .AsParallel()                    
                    .Where(kvp => kvp.Value.State == subject[eAgentName.FARMER].State || kvp.Key == eAgentName.NOBODY)
                    .ForAll(agentToMove =>
                    {
                        var next = subject.copy();
                        eAgentStates nextState = next[eAgentName.FARMER].State == eAgentStates.LEFT_BANK ? eAgentStates.RIGHT_BANK : eAgentStates.LEFT_BANK;
                        next[eAgentName.FARMER].State = nextState;
                        next[agentToMove.Key].State = nextState;
                        result.Add(next);
                    });

                return result;
            };

            Targets.add().conditionIs((subject) =>
            {
                return (subject.Agents.Where(agent => agent.Key != eAgentName.NOBODY)
                    .Count(a => a.Value.State != eAgentStates.LEFT_BANK) == 0);
            });

        }



       
    }
}
