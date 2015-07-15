using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
namespace BacktrackingPlayground.Tests
{
    [TestClass]
    public class WolfKaleSheepTests
    {
        protected WolfKaleSheep subject;

        [TestInitialize]
        public void initializeSubject()
        {
            subject = new WolfKaleSheep();
        }

        [TestMethod]
        public void constraints_LeaveInInitialState_constraintsShouldBeMet()
        {
            bool constraintsAreMet = subject.Constraints.areAllMet(subject);
            Assert.IsTrue(constraintsAreMet, "Initial State of System does not fulfill constraints. Boom.");
        }

        [TestMethod]
        public void constraints_setToTargetState_constraintsShouldBeMet()
        {
            subject.Agents[eAgentName.FARMER].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.KALE].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.NOBODY].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.SHEEP].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            bool constraintsAreMet = subject.Constraints.areAllMet(subject);
            Assert.IsTrue(constraintsAreMet, "Target State of System does not fulfill constraints. This does not make sense.");
        }

        [TestMethod]
        public void constraints_leaveWolfAndSheepUnattended_constraintsShouldNotBeMet()
        {
            // Set Farmer in Transit while leaving all other agents on the initial bank
            subject.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.Constraints.areAllMet(subject);
            Assert.IsFalse(constraintsAreMet, "Sheep and perhaps the kale have been eaten, and you didnt even notice..");
        }

        [TestMethod]
        public void constraints_leaveSheepAndKaleUnattended_constraintsShouldNotBeMet()
        {
            subject.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.Constraints.areAllMet(subject);
            Assert.IsFalse(constraintsAreMet, "The sheep ate the kale, and you didnt even notice..");
        }

        [TestMethod]
        public void constraints_doFirstMoveWithTheSheep_constraintsShouldBeMet()
        {
            subject.Agents[eAgentName.FARMER].State = eAgentStates.IN_TRANSIT;
            subject.Agents[eAgentName.SHEEP].State = eAgentStates.IN_TRANSIT;
            bool constraintsAreMet = subject.Constraints.areAllMet(subject);
            Assert.IsTrue(constraintsAreMet, "It should be safe to take the sheep on the water - does not apply if you got a vegetarian wolf.");
        }

        [TestMethod]
        public void targets_leaveInInitialState_targetsShouldNotBeMet()
        {
            bool targetsAreMet = subject.Targets.AreAllMet(subject);
            Assert.IsFalse(targetsAreMet, "Well, it appears as if I have nothing to to.");
        }

        [TestMethod]
        public void targets_leaveInDesiredState_targetsShouldBeMet()
        {
            //subject.Agents.A(a => a.State = eAgentStates.LEFT_BANK);
            subject.Agents[eAgentName.FARMER].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.KALE].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.NOBODY].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.SHEEP].State = eAgentStates.LEFT_BANK;
            subject.Agents[eAgentName.WOLF].State = eAgentStates.LEFT_BANK;
            bool targetsAreMet = subject.Targets.AreAllMet(subject);
            Assert.IsTrue(targetsAreMet, "It should be safe to take the sheep on the water - does not apply if you got a vegetarian wolf.");
        }

        [TestMethod]
        public void actions_getAllAvailableActionsOnInitialState_succeed()
        {
            var next = subject.Actions.getNext(subject.Agents);
            Assert.IsNotNull(next);
            Assert.IsTrue(next.Count == 4, "Unexpected number of results for next step");
        }

    }
}
*/