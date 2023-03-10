using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
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
                Vector2D VectorToTarget = ME.Target.Clone().Subtract(ME.Position);

                Vector2D desiredVelocity = VectorToTarget.Normalize();
                desiredVelocity.Multiply(ME.MaxSpeed);
                force = desiredVelocity.Subtract(ME.Velocity).Negative();

            }
            return force;
        }
    }
}
