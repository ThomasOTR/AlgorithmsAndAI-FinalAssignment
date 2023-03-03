using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;

namespace FinalAssignmentAAI.Goals
{
    public class Goal_FollowPath : CompositeGoal
    {
        public Goal_FollowPath(MovingEntity ME) : base(ME)
        {
            
        }
        public override void Activate()
        {
            base.Activate();

            /* Add Subgoals */
        }

        public override GoalStatus Process()
        {
            return base.Process();
        }
        public override void Terminate()
        {

        }
    }
}
