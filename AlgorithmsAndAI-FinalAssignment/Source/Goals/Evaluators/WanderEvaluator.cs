using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    /// <summary>
    /// This evaluator calculates the desirability of the entity to walk around.
    /// </summary>
    public class WanderEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            /* Check if this type of goal is already present, if it is, do not add it to the brain */
            if (!ME.Brain.Present(typeof(WanderGoal)))
            {
                /* Check if any subgoals are in the brain. If so, terminate the first one and remove all of them */
                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }
                ME.Brain.AddSubgoal(new WanderGoal(ME));
            }
        }
        public override double CalculateDesirability(MovingEntity ME)
        {
            /* This needs no calculation because entity needs to wander around if all the other evaluators go to lower than 0.4.   */
            return 0.4;
        }
    }
}
