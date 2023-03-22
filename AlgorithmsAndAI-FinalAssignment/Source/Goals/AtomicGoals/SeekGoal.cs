using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{

    /// <summary>
    /// This goal will let the shuttle seek to a target 
    /// </summary>
    public class SeekGoal : Goal
    {
        /* The end position of this goal */
        private Vector2D Target;
        public SeekGoal(MovingEntity movingEntity, Vector2D Target) : base(movingEntity)
        {
            this.Target = Target;
        }
        public override void Activate()
        {
            Status = GoalStatus.Active;

            /* The shuttle will get a target and a seek behaviour added to it's steeringbehaviour */
            Performer.Target = Target;
            Performer.SteeringBehaviours.Add(new SeekBehaviour(Performer));
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* if the Peformer is near the target the goal is completed */
            if (Performer.Position.WithinRange(Performer.Target, 10)) Status = GoalStatus.Completed;

            return Status;
        }
        public override void Terminate()
        {
            /* Reset the Velocity to a default vector to give the next behaviour a fresh start */
            Performer.Velocity = new Vector2D(0, 0);

            /* Remove the arrive steering behaviour from the steeringbehaviours list */
            Performer.SteeringBehaviours.RemoveAll(x => x is SeekBehaviour);

            base.Terminate();

        }
    }
}
