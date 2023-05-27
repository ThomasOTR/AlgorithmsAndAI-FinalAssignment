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
            /* Check if this type of goal is already present, if it is, do not add it to the brain */
            if (!ME.Brain.Present(typeof(GoRefuelGoal)))
            {
                /* Check if any subgoals are in the brain. If so, terminate the first one and remove all of them */
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
            double desirability = 0.0;

            /* If the fuel is higher than 20 or all the FuelStations are occupied desirability will be 0. Otherwise it will be calculated. The lower the wear the higher the desirability will be */
            if (ME.Fuel.currentValue <= 25 && !ME.world.GetStaticEntityListOf<FuelStation>().All(s => s.IsOccupied() == true))
            {
                desirability = 1 - ME.Fuel.currentValue / 50;
            }
            return desirability;
        }
    }
}
