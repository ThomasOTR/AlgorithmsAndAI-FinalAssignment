using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    /// <summary>
    /// This goal will move the Delivery Point and drop the cargo off. 
    /// </summary>
    public class DeliverCargoGoal : CompositeGoal
    {
        /// <summary>
        /// The cargo that will be delivered.
        /// </summary>
        private Cargo cargo;
        public DeliverCargoGoal(MovingEntity ME, Cargo cargo) : base(ME)
        {
            this.cargo = cargo;
        }

        public override void Activate()
        {
            /* Check to make this goal go fluently*/
            if (cargo == null) Status = GoalStatus.Failed;
            else if (cargo.TargetLocation == null) Status = GoalStatus.Failed;
            else
            {
                /* Claim the DeliveryStation so nobody else will go there. */
                DeliveryStation DS = cargo.TargetLocation;

                if (DS.GetOccupationState() == OccupationState.Open) DS.Claim(Performer);

                /* Add the goals in the opposite order that it needs to happen. Because of the stack implementation */
                Subgoals.Push(new DropOffCargoGoal(Performer, DS));
                Subgoals.Push(new ArriveGoal(Performer, DS.Position));
            }
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        public override void Terminate()
        {
            /* Leave the location so others can go to it */
            cargo.TargetLocation.Leave();

            /* Terminate it as all the goals will do on default */
            base.Terminate();

        }

    }
}
