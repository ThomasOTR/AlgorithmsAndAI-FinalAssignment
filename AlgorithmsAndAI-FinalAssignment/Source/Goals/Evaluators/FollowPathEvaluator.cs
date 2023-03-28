using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using FinalAssignmentAAI.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class FollowPathEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            /* Check if this type of goal is already present, if it is, do not add it to the brain */
            if (!ME.Brain.Present(typeof(FollowPathGoal)))
            {
                /* Check if any subgoals are in the brain. If so, terminate the first one and remove all of them */
                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }
                ME.Brain.AddSubgoal(new FollowPathGoal(ME));
            }

        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            /* If the shortest path length or visited nodes length are zero. Desirability is 0. This means the PathPlanning has failed or has not started */
            if (ME.world.graph.GetShortestPath().Count == 0 || ME.world.graph.GetVisitedNodes().Count == 0) return 0;
            /* If the entity that wants to follow path is not the designed entity, it is also not desirable */
            if (!ME.Equals(ME.world.MainAgent)) return 0;

            /* Otherwise it is very desirable to do this. */
            return 1;
        }
    }
}
