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
            DeliveryStation DS = cargo.TargetLocation;
            DS.Claim(Performer);

            Subgoals.Push(new DropOffCargoGoal(Performer, DS));
            Subgoals.Push(new ArriveGoal(Performer, DS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        public override void Terminate()
        {
            cargo.TargetLocation.Leave();

            base.Terminate();

        }

    }
}
