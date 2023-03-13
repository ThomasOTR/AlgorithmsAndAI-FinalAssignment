using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using FinalAssignmentAAI.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class FollowPathEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(FollowPathGoal)))
            {
                ME.Brain.AddSubgoal(new FollowPathGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.world.graph.GetShortestPath().Count == 0 || ME.world.graph.GetVisitedNodes().Count == 0) return 0;

            return 1;
        }
    }
}
