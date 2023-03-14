using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will drop off the cargo from the shuttle to the Delivery station.
    /// </summary>
    public class DropOffCargoGoal : Goal
    {
        /* The destination of the Cargo */
        private DeliveryStation station;

        /* The value that will be increased each Process() call*/
        private float WaitAmount = 0;
        public DropOffCargoGoal(MovingEntity movingEntity, DeliveryStation station) : base(movingEntity)
        {
            this.station = station;
        }

        public override GoalStatus Process()
        {

            if (Status == GoalStatus.Inactive) Activate();

            /* With this line the Performer will interact with the station. In this case interact is moving the cargo from shuttle to station */
            station.Interact(Performer);

            /* The interaction needs only 1 call. That is why i have added a check to let the shuttle at least be busy for at least 5 seconds */
            if (WaitAmount == 5000)
            {
                Status = GoalStatus.Completed;
            }
            WaitAmount += 50;

            return Status;
        }
    }
}
