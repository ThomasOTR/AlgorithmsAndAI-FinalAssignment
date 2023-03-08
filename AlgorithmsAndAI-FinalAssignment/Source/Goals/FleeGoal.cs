using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace FinalAssignmentAAI.Goals
{
    public class FleeGoal : Goal
    {
        private Vector2D targetFleeingFrom;
        public FleeGoal(MovingEntity ME, Vector2D Target) : base(ME)
        {
            targetFleeingFrom = Target;
        }
        public override void Activate()
        {
            Status = GoalStatus.Active;
            Performer.Target = targetFleeingFrom;
            Performer.SteeringBehaviours.Add(new FleeBehaviour(Performer));
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* if the Peformer is a high distance away from the target 
             * the goal is completed
             */
            if (Performer.Position.Distance(Performer.Target) > 500) Status = GoalStatus.Completed;
            
            return Status;
        }
        public override void Terminate()
        {
            Performer.Velocity = new Vector2D();
            Performer.SteeringBehaviours.Clear();
        }
    }
}
