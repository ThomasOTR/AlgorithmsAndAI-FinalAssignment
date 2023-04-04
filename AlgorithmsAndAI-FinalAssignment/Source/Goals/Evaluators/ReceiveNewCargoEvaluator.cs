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
            /* Check if this type of goal is already present, if it is, do not add it to the brain */
            if (!ME.Brain.Present(typeof(ReceiveNewCargoGoal)))
            {
                /* Check if any subgoals are in the brain. If so, terminate the first one and remove all of them */
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
            /* Desirability is 0 if there is already cargo or if all the warehouses are occupied or when the FuzzyLogic is not loaded in correctly */
            if (ME.cargo != null || Form1.ConfigurationFileLoadedIn == false) return 0.0;

            if (ME.world.GetStaticEntityListOf<CargoWarehouse>().All(s => s.IsOccupied() == true) ||
                ME.world.GetStaticEntityListOf<CargoWarehouse>().All(s => s.CargoForDelivery.Count == 0)) return 0.0;

            /* If both the checks are false, desirability is 0.5 */
            return 0.5;
        }
    }
}
