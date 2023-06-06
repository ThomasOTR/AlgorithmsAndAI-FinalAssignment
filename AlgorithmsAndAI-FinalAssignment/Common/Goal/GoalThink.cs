using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goals
{
    /// <summary>
    /// The brain of each MovingEntity. The brain will decide the best goals by evaluators.
    /// </summary>
    public class GoalThink : CompositeGoal
    {
        public List<GoalEvaluator> GoalEvaluators;
        public GoalThink(MovingEntity ME) : base(ME)
        {
            GoalEvaluators = new List<GoalEvaluator>();
        }

        /// <summary>
        /// A method to add multiple evaluators in 1 method call
        /// </summary>
        /// <param name="evaluators"></param>
        public void AddEvaluators(List<GoalEvaluator> evaluators)
        {
            foreach (GoalEvaluator evaluator in evaluators)
            {
                GoalEvaluators.Add(evaluator);
            }
        }
        public override GoalStatus Process()
        {
            if (Subgoals.Count == 0 || Subgoals.First() is WanderGoal) Arbitrate();
            return ProcessSubgoals();
        }
        public override void Activate()
        {
            base.Activate();
            Arbitrate();
        }
        /// <summary>
        /// A method to decide the most desirable goal
        /// </summary>
        public void Arbitrate()
        {
            double Highest = 0;
            GoalEvaluator? MostDesirable = null;
            foreach (GoalEvaluator GE in GoalEvaluators)
            {
                double desirableValue = GE.CalculateDesirability(Performer);
                if (desirableValue > Highest)
                {
                    Highest = desirableValue;
                    MostDesirable = GE;
                }
            }

            if (Highest != 0 && MostDesirable != null)
            {
                MostDesirable.AddGoal(Performer);
            }

        }

        /// <summary>
        /// A method to check if a goal is already added to the subgoals.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Present(Type type)
        {
            if (Subgoals.Count > 0 && Subgoals.First() != null)
            {
                return Subgoals.Peek().GetType() == type;
            }
            else return false;
        }
    }
}
