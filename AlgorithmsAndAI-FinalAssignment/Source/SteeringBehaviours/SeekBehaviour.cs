using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D force = new Vector2D();

            if (ME.Target != null)
            {
                Vector2D VectorToTarget = ME.Target.Clone().Subtract(ME.Position);

                Vector2D desiredVelocity = VectorToTarget.Normalize();
                desiredVelocity.Multiply(ME.MaxSpeed);
                return desiredVelocity.Subtract(ME.Velocity);
            }
            return force;
        }
    }
}
