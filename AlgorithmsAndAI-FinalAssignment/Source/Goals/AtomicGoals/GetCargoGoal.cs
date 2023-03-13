using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will collect the best cargo suited to the shuttle
    /// </summary>
    public class GetCargoGoal : Goal
    {
        private CargoWarehouse CW;
        public GetCargoGoal(MovingEntity movingEntity, CargoWarehouse CW) : base(movingEntity)
        {
            this.CW = CW;
        }


        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* The interaction between the Warehouse and the shuttle. This time the interaction is loading a cargo into the shuttle */
            CW.Interact(Performer);

            // TODO: Add 5 second wait 

            if (Performer.cargo != null) Status = GoalStatus.Completed;

            return Status;

        }
    }
}
