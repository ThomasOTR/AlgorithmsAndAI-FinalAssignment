using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    public enum GoalStatus { Completed, Active, Inactive, Failed }
    public abstract class Goal
    {
        public GoalStatus Status;
        public MovingEntity Performer;
        public Goal(MovingEntity movingEntity) 
        {
            Performer= movingEntity;
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
        public abstract void Terminate();

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
