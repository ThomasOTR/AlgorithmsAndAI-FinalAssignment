using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class GoRefuelEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(GoRefuelGoal)))
            {
                System.Diagnostics.Debug.WriteLine("refuel");

                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }

                ME.Brain.AddSubgoal(new GoRefuelGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.world.GetStaticEntityListOf<PetrolStation>().All(s => s.IsOccupied() == true)) return 0.0;
            if (ME.Fuel.currentValue >= 75 && ME.cargo != null) return 0.1;
            return 1 - (ME.Fuel.currentValue / ME.Fuel.max);
        }
    }
}
