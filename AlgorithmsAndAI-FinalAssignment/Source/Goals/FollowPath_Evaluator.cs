using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals
{
    public class FollowPathEvaluator : Goal_Evaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            ME.Brain.AddGoal_FollowPath();
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.world.graph.GetShortestPath().Count == 0 || ME.world.graph.GetVisitedNodes().Count == 0) return 0;

            return 0.5;
        }
    }
}
