using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;
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
        public DeliverCargoGoal(MovingEntity movingEntity, Cargo cargo) : base(movingEntity)
        {
            this.cargo = cargo;
        }

        public override void Activate()
        {
            DeliveryStation DS = cargo.TargetLocation;

            Subgoals.Push(new DropOffCargoGoal(Performer, DS));
            Subgoals.Push(new ArriveGoal(Performer, DS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

    }
}
