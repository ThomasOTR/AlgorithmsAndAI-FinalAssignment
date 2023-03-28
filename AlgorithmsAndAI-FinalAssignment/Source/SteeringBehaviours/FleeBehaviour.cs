using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    /// <summary>
    /// This behaviour lets the Entity run away from a target
    /// </summary>
    public class FleeBehaviour : SteeringBehaviour
    {
        public FleeBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D force = new();
            if (ME.Target != null)
            {
                /* Determine the Vector to the target by subtracting the Position of the entity from the Target position*/
                Vector2D VectorToTarget = ME.Target.Clone().Subtract(ME.Position);

                /* Calculate the velocity from the entity to the target */
                Vector2D desiredVelocity = VectorToTarget.Normalize();
                desiredVelocity.Multiply(ME.MaxSpeed);
                force = desiredVelocity.Subtract(ME.Velocity);

                /* Convert the Velocity to a negative velocity so it is facing in the opposite direction of the target */
                force = force.Negative();

            }
            return force;
        }
    }
}
