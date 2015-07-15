using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BacktrackingLibraryPlayground;
using BacktrackingLibraryPlayground.WolfKaleSheep;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;

namespace BacktrackingLibraryPlayground.Tests
{
    [TestClass]
    public class WolfKaleSheepDemoTests
    {
        protected WolfKaleSheepProblem subject;
        protected WolfKaleSheepAgentModel agentModel;

        [TestInitialize]
        public void initializeSubject()
        {
            subject = new WolfKaleSheepProblem();
            agentModel = new WolfKaleSheepAgentModel();
        }

        [TestMethod]
        public void constraints_LeaveInInitialState_constraintsShouldBeMet()
        {
            bool constraintsAreMet = subject.SolverBase.Constraints.areAllMet(agentModel);
            Assert.IsTrue(constraintsAreMet, "Initial State of System does not fulfill constraints. Boom.");
        }

        [TestMethod]
        public void constraints_setToTargetState_constraintsShouldBeMet()
        {
            agentModel.Agents[eAgentName.FARMER].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.KALE].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.NOBODY].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.SHEEP].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            bool constraintsAreMet = subject.SolverBase.Constraints.areAllMet(agentModel);
            Assert.IsTrue(constraintsAreMet, "Target State of System does not fulfill constraints. This does not make sense.");
        }

        [TestMethod]
        public void constraints_leaveWolfAndSheepUnattended_constraintsShouldNotBeMet()
        {
            // Set Farmer in Transit while leaving all other agents on the initial bank
            agentModel.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.SolverBase.Constraints.areAllMet(agentModel);
            Assert.IsFalse(constraintsAreMet, "Sheep and perhaps the kale have been eaten, and you didnt even notice..");
        }

        [TestMethod]
        public void constraints_leaveSheepAndKaleUnattended_constraintsShouldNotBeMet()
        {
            agentModel.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.SolverBase.Constraints.areAllMet(agentModel);
            Assert.IsFalse(constraintsAreMet, "The sheep ate the kale, and you didnt even notice..");
        }

        [TestMethod]
        public void constraints_doFirstMoveWithTheSheep_constraintsShouldBeMet()
        {
            agentModel.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            agentModel.Agents[eAgentName.SHEEP].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.SolverBase.Constraints.areAllMet(agentModel);
            Assert.IsTrue(constraintsAreMet, "It should be safe to take the sheep on the water - does not apply if you got a vegetarian wolf.");
        }
        
        [TestMethod]
        public void targets_leaveInInitialState_targetsShouldNotBeMet()
        {
            bool targetsAreMet = subject.SolverBase.Targets.AreAllMet(agentModel);
            Assert.IsFalse(targetsAreMet, "Well, it appears as if I have nothing to to.");
        }
        
        [TestMethod]
        public void targets_leaveInDesiredState_targetsShouldBeMet()
        {
            //subject.Agents.A(a => a.State = eAgentStates.LEFT_BANK);
            agentModel.Agents[eAgentName.FARMER].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.KALE].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.NOBODY].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.SHEEP].State = eAgentStates.LEFT_BANK;
            agentModel.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            bool targetsAreMet = subject.SolverBase.Targets.AreAllMet(agentModel);
            Assert.IsTrue(targetsAreMet, "It should be safe to take the sheep on the water - does not apply if you got a vegetarian wolf.");
        }
        
        [TestMethod]
        public void actions_getAllAvailableActionsOnInitialState_succeed()
        {
            var next = subject.SolverBase.Actions.getNext(agentModel);
            Trace.WriteLine(JsonConvert.SerializeObject(next,Formatting.Indented));
            Assert.IsNotNull(next);
            Assert.IsTrue(next.Count == 4, "Unexpected number of results for next step");
        }

        [TestMethod]
        [Description("Detect invalid edges")]
        public void actions_getAllAvailableActionsOnInitialState_farmerShouldMoveInAnyEvent()
        {
            List<WolfKaleSheepAgentModel> next = subject.SolverBase.Actions.getNext(agentModel);            
            Assert.IsNotNull(next);
            bool hasFarmerMovedToOtherBankInAllEvents = next.TrueForAll(item => item.Agents[eAgentName.FARMER].State == eAgentStates.LEFT_BANK);
            Assert.IsTrue(hasFarmerMovedToOtherBankInAllEvents,"Farmer did not move in any event.");
        }

        [TestMethod]
        public void actions_getAllAvailableActionsOnInitialState_getAtLeastTwoForbiddenNextActions()
        {
            List<WolfKaleSheepAgentModel> next = subject.SolverBase.Actions.getNext(agentModel);
            Assert.IsNotNull(next);
            
            int forbiddenNexts = 0;
            foreach(WolfKaleSheepAgentModel nextItem in next)
            {
                Trace.WriteLine("Testing" + JsonConvert.SerializeObject(nextItem));
                forbiddenNexts += subject.SolverBase.Constraints.areAllMet(nextItem) == true ? 0 : 1;
            }

            Assert.IsTrue(forbiddenNexts >= 2);
        }

        [TestMethod]
        [TestCategory("Solver")]
        public void solver_trySolveProblemWithDefaultSettings_succeed()
        {
            subject.SolverBase.ApproachModel.solve(agentModel);
            Trace.WriteLine("Has found?");
            Trace.WriteLine("Approach: " + JsonConvert.SerializeObject(subject.SolverBase.ApproachModel.getApproach()));
        }
         
    }
}
