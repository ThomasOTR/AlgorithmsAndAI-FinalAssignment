using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will repair the shuttle
    /// </summary>
    public class RepairGoal : Goal
    {
        /* The repairstation that will repair the shuttle */
        private RepairStation RS;
        public RepairGoal(MovingEntity movingEntity, RepairStation RS) : base(movingEntity)
        {
            this.RS = RS;
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* Interaction between the Repair station and a shuttle. This time the shuttle will be repaired by the station */
            RS.Interact(Performer);

            /* This goal is completed when the value is at it's max */
            if (Performer.Wear.currentValue == Performer.Wear.max) Status = GoalStatus.Completed;

            return Status;


        }
    }
}
