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
        public PetrolStation PS;
        public RefuelGoal(MovingEntity ME, PetrolStation PS) : base(ME)
        {
            this.PS = PS;
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* Interaction between the PetrolStation and a shuttle. This time the shuttle will be refueled. */
            PS.Interact(Performer);

            /* This goal is complete when the fuel is at it's max */
            if (Performer.Fuel.currentValue == Performer.Fuel.max) Status = GoalStatus.Completed;

            return Status;
        }
    }
}
