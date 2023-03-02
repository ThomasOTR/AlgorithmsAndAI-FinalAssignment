using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    public class CompositeGoal : Goal
    {
        public Stack<Goal> Subgoals;
        public CompositeGoal(MovingEntity ME) : base(ME) 
        {
            Subgoals = new Stack<Goal>();
        }
        public void addSubgoal(Goal goal)
        {
            Subgoals.Push(goal);
        }
        public override GoalStatus Process()
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
