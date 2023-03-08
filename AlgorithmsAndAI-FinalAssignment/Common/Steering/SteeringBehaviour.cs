using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Steering
{
    /// <summary>
    /// Base class of each Steering Behaviour.
    /// </summary>
    public abstract class SteeringBehaviour
    {
        /// <summary>
        /// The Moving Entity that will perform the behaviour.
        /// </summary>
        public MovingEntity ME { get; set; }

        public SteeringBehaviour(MovingEntity ME)
        {
            this.ME = ME;
        }

        /// <summary>
        /// Method to calculate the steering force.
        /// </summary>
        /// <returns></returns>
        public abstract Vector2D Calculate();
    }
}
