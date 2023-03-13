using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class GoRefuelEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(GoRefuelGoal)))
            {
                ME.Brain.AddSubgoal(new GoRefuelGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            if (ME.world.GetStaticEntityListOf<PetrolStation>().All(s => s.IsOccupied() == true)) return 0.0;
            if (ME.Fuel.currentValue >= 75 || ME.cargo != null) return 0.1;
            return (ME.Fuel.currentValue / ME.Fuel.max);
        }
    }
}
