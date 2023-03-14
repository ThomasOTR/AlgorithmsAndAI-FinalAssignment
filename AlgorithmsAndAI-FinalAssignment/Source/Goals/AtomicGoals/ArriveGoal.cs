using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will start the ArriveBehaviour and will stop this behaviour if the shuttle is at his location
    /// </summary>
    public class ArriveGoal : Goal
    {
        /* The position where the shuttle will arrive eventually */
        private Vector2D Target;
        public ArriveGoal(MovingEntity ME, Vector2D Target) : base(ME)
        {
            this.Target = Target;
        }
        public override void Activate()
        {
            /* This will update the status to Active */
            base.Activate();

            /* Add the arrive behaviour and the target to our shuttle */
            Performer.Target = Target;
            Performer.SteeringBehaviours.Add(new ArriveBehaviour(Performer));

        }
        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* This goal will be completed if the shuttle is within a few pixels of its precise location*/
            if (Performer.Position.WithinRange(Performer.Target, 5)) Status = GoalStatus.Completed;

            return Status;
        }
        public override void Terminate()
        {
            /* Reset the Velocity to a default vector to give the next behaviour a fresh start */
            Performer.Velocity = new Vector2D(0, 0);

            /* Remove the arrive steering behaviour from the steeringbehaviours list */
            Performer.SteeringBehaviours.RemoveAll(x => x is ArriveBehaviour);

        }
    }
}
