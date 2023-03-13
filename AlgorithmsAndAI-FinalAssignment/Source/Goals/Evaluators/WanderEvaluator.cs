using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class WanderEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(WanderGoal)))
            {
                ME.Brain.AddSubgoal(new WanderGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            return 0.4;
        }
    }
}
