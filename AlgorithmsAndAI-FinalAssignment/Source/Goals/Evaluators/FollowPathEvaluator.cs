using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using FinalAssignmentAAI.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class FollowPathEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(FollowPathGoal)))
            {
                if (ME.Brain.Subgoals.Count > 0) ME.Brain.Subgoals.Peek().Terminate();
                ME.Brain.AddSubgoal(new FollowPathGoal(ME));
            }

        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.world.graph.GetShortestPath().Count == 0 || ME.world.graph.GetVisitedNodes().Count == 0) return 0;
            if (!ME.Equals(ME.world.MainAgent)) return 0;

            System.Diagnostics.Debug.WriteLine("SP: " + ME.world.graph.GetShortestPath().Count);
            System.Diagnostics.Debug.WriteLine("vn: " + ME.world.graph.GetVisitedNodes().Count);

            return 1;
        }
    }
}
