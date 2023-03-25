using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class ReceiveNewCargoEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(ReceiveNewCargoGoal)))
            {
                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }
                ME.Brain.AddSubgoal(new ReceiveNewCargoGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.cargo != null) return 0.0;
            if (ME.world.GetStaticEntityListOf<CargoWarehouse>().All(s => s.IsOccupied() == true)) return 0.0;

            return 0.5;
        }
    }
}
