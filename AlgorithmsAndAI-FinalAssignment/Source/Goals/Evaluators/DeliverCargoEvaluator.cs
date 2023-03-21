using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class DeliverCargoEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(DeliverCargoGoal)) && ME.cargo != null)
            {
                if (ME.Brain.Subgoals.Count > 0) ME.Brain.Subgoals.Peek().Terminate();
                ME.Brain.AddSubgoal(new DeliverCargoGoal(ME, ME.cargo));
            }

        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.cargo == null) return 0;
            else if (ME.cargo.TargetLocation == null) return 0;
            else if (ME.cargo.TargetLocation.IsOccupied()) return 0;
            return 0.5;
        }
    }
}
