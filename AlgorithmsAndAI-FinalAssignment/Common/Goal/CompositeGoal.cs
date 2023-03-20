using AlgorithmsAndAI_FinalAssignment.Common.Entities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goals
{
    public abstract class CompositeGoal : Goal
    {
        /* The subgoals of this compositegoal */
        public Stack<Goal> Subgoals;
        public CompositeGoal(MovingEntity ME) : base(ME)
        {
            Subgoals = new Stack<Goal>();
        }

        /// <summary>
        /// Method to add a subgoal. 
        /// </summary>
        /// <param name="goal"></param>
        public void AddSubgoal(Goal goal)
        {
            Subgoals.Push(goal);
        }

        /// <summary>
        /// Method to process the subgoals. 
        /// </summary>
        /// <returns>Status of CompositeGoal </returns>
        public GoalStatus ProcessSubgoals()
        {
            if (Status == GoalStatus.Inactive) Activate();
            GoalStatus status;

            if (Subgoals.Count != 0)
            {
                Subgoals.Peek().Process();

                if (Subgoals.Peek().Is(GoalStatus.Completed) || Subgoals.Peek().Is(GoalStatus.Failed))
                {
                    Subgoals.Peek().Terminate();
                    Subgoals.Pop();
                }
                status = GoalStatus.Active;
            }
            else
            {
                status = GoalStatus.Completed;
            }
            Status = status;
            return Status;
        }
    }
}
