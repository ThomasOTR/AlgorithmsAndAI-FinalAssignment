using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class ArriveBehaviour : SteeringBehaviour
    {
        private double slowingRadius = 0;
        public ArriveBehaviour(MovingEntity ME) : base(ME)
        {
            slowingRadius = ME.MaxSpeed * 10;
        }

        public override Vector2D Calculate()
        {
            /* A target is needed for the Arrive Behavior. */
            if (ME.Target != null)
            {
                /* Determine the Vector to the target by subtracting the Position of the entity from the Target position */
                Vector2D toTarget = ME.Target.Clone().Subtract(ME.Position);
                if (toTarget == null) return new Vector2D();

                /* Calculate the distance to the target.*/
                double distance = toTarget.Length();
                if (distance <= 0)
                {
                    return new Vector2D(0, 0);
                }

                /* Speed is default on max speed*/
                double speed = ME.MaxSpeed;

                /* If the position is within the range, decrease the speed */
                if (ME.Position.WithinRange(ME.Target, 100)) speed = (distance / 100) * ME.MaxSpeed;

                /* Calculate the velocity as normal */
                Vector2D desiredVelocity = toTarget.Multiply(speed).Divide(distance);
                return desiredVelocity.Subtract(ME.Velocity);
            }
            /* If there is no target, return a default Vector2D. */
            else return new Vector2D();
        }
    }
}
