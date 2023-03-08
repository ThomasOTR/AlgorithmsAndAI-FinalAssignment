using AlgorithmsAndAI_FinalAssignment.Common.Entities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    public enum GoalStatus { Completed, Active, Inactive, Failed }
    public abstract class Goal
    {
        /* Status of the Goal, which will be used to process the goal correctly*/
        public GoalStatus Status;

        /* Entity which is performing this goal */
        public MovingEntity Performer;

        public Goal(MovingEntity movingEntity)
        {
            Performer = movingEntity;
            Status = GoalStatus.Inactive;
        }
        /// <summary>
        /// A simple method to activate the Goal
        /// </summary>
        public virtual void Activate() { Status = GoalStatus.Active; }

        /// <summary>
        /// A method that keeps the goal running and checks if its completed
        /// </summary>
        /// <returns></returns>
        public abstract GoalStatus Process();

        /// <summary>
        /// A method to disable the enabled behaviour;
        /// </summary>
        public virtual void Terminate() { }

        /// <summary>
        /// A simple method to check if the status of the goal is correct;
        /// </summary>
        /// <returns></returns>
        public bool Is(GoalStatus type)
        {
            return (Status == type);
        }

    }
}
