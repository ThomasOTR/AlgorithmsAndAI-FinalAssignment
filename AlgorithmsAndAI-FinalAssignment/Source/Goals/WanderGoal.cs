using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace FinalAssignmentAAI.Goals
{
    public class WanderGoal : Goal
    {
        public WanderGoal(MovingEntity ME) : base(ME) { }
        public override void Activate()
        {
            Status = GoalStatus.Active;
            Performer.SteeringBehaviours.Add(new WanderBehaviour(Performer));
        }
        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();
            
            return Status;
        }
        public override void Terminate()
        {
            Status = GoalStatus.Completed;
            Performer.SteeringBehaviours.Clear();
        }
    }
}
