using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    public class RefuelGoal : Goal
    {
        public PetrolStation PS;
        public RefuelGoal(MovingEntity ME, PetrolStation PS) : base(ME)
        {
            this.PS = PS;
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            Performer.Fuel.Increase(PS.FuelingSpeed);

            if (Performer.Fuel.currentValue == Performer.Fuel.max) Status = GoalStatus.Completed;

            return Status;
        }
    }
}
