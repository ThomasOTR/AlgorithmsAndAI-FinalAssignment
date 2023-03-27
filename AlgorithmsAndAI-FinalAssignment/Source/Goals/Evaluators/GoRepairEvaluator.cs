using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class GoRepairEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            if (!ME.Brain.Present(typeof(GoRepairGoal)))
            {
                System.Diagnostics.Debug.WriteLine("repair");

                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }

                ME.Brain.AddSubgoal(new GoRepairGoal(ME));
            }
        }

        public override double CalculateDesirability(MovingEntity ME)
        {
            double desirability = 0.0;
            if (ME.Wear.currentValue <= 20 && !ME.world.GetStaticEntityListOf<RepairStation>().All(s => s.IsOccupied() == true))
            {
                desirability = 1 - ME.Wear.currentValue / 40;
            }
            return desirability;
        }
    }
}
