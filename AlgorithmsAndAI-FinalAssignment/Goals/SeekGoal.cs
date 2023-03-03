using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Goals
{
    public class SeekGoal : Goal
    {
        private Vector2D Target;
        public SeekGoal(MovingEntity movingEntity, Vector2D Target) : base(movingEntity) 
        { 
            this.Target= Target;
        }
        public override void Activate()
        {
            Status = GoalStatus.Active;
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
            Performer.Velocity = new Vector2D();
            Performer.SteeringBehaviours.Clear();
        }
    }
}
