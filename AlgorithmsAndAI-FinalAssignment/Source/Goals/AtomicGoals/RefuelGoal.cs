using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will refuel a shuttle
    /// </summary>
    public class RefuelGoal : Goal
    {
        public FuelStation FS;
        public RefuelGoal(MovingEntity ME, FuelStation FS) : base(ME)
        {
            this.FS = FS;
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* Interaction between the FuelStation and a shuttle. This time the shuttle will be refueled. */
            FS.Interact(Performer);

            /* This goal is complete when the fuel is at it's max */
            if (Performer.Fuel.currentValue == Performer.Fuel.max) Status = GoalStatus.Completed;

            return Status;
        }
    }
}
