using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals
{
    public class RepairGoal : Goal
    {
        private RepairStation RS;
        public RepairGoal(MovingEntity movingEntity, RepairStation RS) : base(movingEntity)
        {
            this.RS = RS;
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            Performer.Wear.Increase(RS.RepairSpeed);

            if (Performer.Wear.currentValue == Performer.Wear.max) Status = GoalStatus.Completed;

            return Status;


        }
    }
}
