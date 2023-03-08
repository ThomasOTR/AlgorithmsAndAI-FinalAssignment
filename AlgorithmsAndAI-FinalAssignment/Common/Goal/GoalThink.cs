using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using FinalAssignmentAAI.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    public class GoalThink : CompositeGoal
    {
        private List<Goal_Evaluator> GoalEvaluators;
        public GoalThink(MovingEntity ME) : base(ME)
        {
            GoalEvaluators = new List<Goal_Evaluator>();
        }
        public void AddEvaluator(Goal_Evaluator evaluator)
        {
            GoalEvaluators.Add(evaluator);
        }
        public override GoalStatus Process()
        {
            if (Subgoals.Count == 0 || Subgoals.First() is WanderGoal) Arbitrate();
            return ProcessSubgoals();
        }
        public override void Activate()
        {
            Arbitrate();
            base.Activate();
        }
        /// <summary>
        /// A method to decide the most desirable goal
        /// </summary>
        public void Arbitrate()
        {
            double Highest = 0;
            Goal_Evaluator MostDesirable = null;
            foreach (Goal_Evaluator GE in GoalEvaluators)
            {
                double desirableValue = GE.CalculateDesirability(Performer);
                if (desirableValue > Highest)
                {
                    Highest = desirableValue;
                    MostDesirable = GE;
                }
            }
            if (Highest != 0)
            {
                if (Subgoals.Count > 0)
                {
                    if (Subgoals.Peek() is WanderGoal)
                    {
                        Subgoals.Peek().Terminate();
                        Subgoals.Pop();
                    }
                }
                MostDesirable.AddGoal(Performer);
            }
            else AddGoal_Wander();

        }

        /// <summary>
        /// A method to check if a goal is already added to the subgoals.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Present(Type type)
        {
            if (Subgoals.Count > 0)
            {
                return Subgoals.Peek().GetType() == type;
            }
            else return false;
        }

        public void AddGoal_FollowPath()
        {
            if (!Present(typeof(Goal_FollowPath)))
            {
                AddSubgoal(new Goal_FollowPath(Performer));
            }
        }
        public void AddGoal_Wander()
        {
            if (!Present(typeof(WanderGoal)))
            {
                AddSubgoal(new WanderGoal(Performer));
            }
        }

    }
}
