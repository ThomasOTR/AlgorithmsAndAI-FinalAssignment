using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    /// <summary>
    /// This behaviour lets the Entity seek to a target on the canvas
    /// </summary>
    public class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D force = new();

            /* If there is no target, there is no direction the entity can go to */
            if (ME.Target != null)
            {
                /* Calculate Vector to a target */
                Vector2D VectorToTarget = ME.Target.Clone().Subtract(ME.Position);

                /* Calculate the velocity from the entity to the target */
                Vector2D desiredVelocity = VectorToTarget.Normalize();
                desiredVelocity.Multiply(ME.MaxSpeed);
                return desiredVelocity.Subtract(ME.Velocity);

            }
            return force;
        }
    }
}
