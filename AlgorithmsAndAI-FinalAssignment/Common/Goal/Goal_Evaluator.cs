using AlgorithmsAndAI_FinalAssignment.Common.Entities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    /// <summary>
    /// Class to evaluate if a goal is desirable to be performed. This will check specific stats to calculate the desirability
    /// </summary>
    public abstract class Goal_Evaluator
    {
        /// <summary>
        /// Method to calculate desirability of the type of goal.
        /// </summary>
        /// <param name="ME">Entity which will get this goal if it is desirable.</param>
        /// <returns></returns>
        public abstract double CalculateDesirability(MovingEntity ME);

        /// <summary>
        /// Method to add a goal to the GoalThink | Brain
        /// </summary>
        /// <param name="ME">Entity which will get this goal</param>
        public abstract void AddGoal(MovingEntity ME);
    }
}
