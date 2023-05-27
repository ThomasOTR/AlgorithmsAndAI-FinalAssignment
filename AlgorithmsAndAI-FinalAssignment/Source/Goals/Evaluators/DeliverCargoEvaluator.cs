using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators
{
    public class DeliverCargoEvaluator : GoalEvaluator
    {
        public override void AddGoal(MovingEntity ME)
        {
            /* Check if this type of goal is already present, if it is, do not add it to the brain */
            if (!ME.Brain.Present(typeof(DeliverCargoGoal)) && ME.cargo != null)
            {
                if (ME.Brain.Subgoals.Count > 0)
                {
                    ME.Brain.Subgoals.Peek().Terminate();
                    ME.Brain.Subgoals.Clear();
                }

                ME.Brain.AddSubgoal(new DeliverCargoGoal(ME, ME.cargo));
            }

        }

        public override double CalculateDesirability(MovingEntity ME)
        {

            /* If there is no cargo, nothing can be delivered */
            if (ME.cargo == null) return 0;

            DeliveryStation? Target = ME.cargo.TargetLocation;

            /* If there is no location where the cargo needs to go to */
            if (Target == null) return 0;

            else if (Target.OccupiedBy != null && Target.IsOccupied())
            {
                if (!Target.OccupiedBy.Equals(ME)) return 0;
            }

            /* Otherwise it's fine and it is desirable */
            return 0.5;
        }
    }
}
