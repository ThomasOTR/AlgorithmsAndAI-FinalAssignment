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
            if (goal != null) Subgoals.Push(goal);
        }

        /// <summary>
        /// Method to process the subgoals. 
        /// </summary>
        /// <returns>Status of CompositeGoal </returns>
        public GoalStatus ProcessSubgoals()
        {
            if (Status == GoalStatus.Inactive) Activate();
            GoalStatus status;

            /* A composite goal is Completed when all the subgoals are completed. Until all the goals are done, it will process all of them.*/
            if (Subgoals.Count != 0)
            {
                /* If the next subgoal is not null. Process it.*/
                if (Subgoals.First() != null)
                {
                    Subgoals.Peek().Process();
                    /* if the goal is failed or completed, terminate the goal and pop it. */
                    if (Subgoals.Peek().Is(GoalStatus.Completed) || Subgoals.Peek().Is(GoalStatus.Failed))
                    {
                        Subgoals.Peek().Terminate();
                        Subgoals.Pop();
                    }
                }
                /* Until all the goals are done, the composite goal is active */
                status = GoalStatus.Active;
            }
            /* Else it will be completed*/
            else status = GoalStatus.Completed;

            Status = status;
            return Status;
        }
    }
}
