using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will let the shuttle wander around.
    /// </summary>
    public class WanderGoal : Goal
    {
        public WanderGoal(MovingEntity ME) : base(ME) { }
        public override void Activate()
        {
            Status = GoalStatus.Active;

            /* The shuttle will receive the wander */
            Performer.SteeringBehaviours.Add(new WanderBehaviour(Performer));
        }
        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            return Status;
        }
        public override void Terminate()
        {
            /* Reset the Velocity to a empty vector to give the next behaviour a fresh start */
            Performer.Velocity = new Vector2D();

            /* Remove the arrive steering behaviour from the steeringbehaviours list */
            Performer.SteeringBehaviours.ForEach(sb => { if (sb is WanderBehaviour) Performer.SteeringBehaviours.Remove(sb); });
        }
    }
}
