using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    /// <summary>
    /// This behaviour lets the Entity walk around the canvas
    /// </summary>
    public class WanderBehaviour : SteeringBehaviour
    {
        const double DistanceToWanderPoint = 80;
        const double WanderRadius = 30;
        double randomValue = 20;
        public WanderBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            /* Creating a point in the same direction. This is very helpfull so we can add small random additions to move the entity quite normal */
            Vector2D WanderPoint = ME.Velocity.Clone();
            if (WanderPoint.Equals(new Vector2D())) WanderPoint = new Vector2D(0.1, 0.1);

            WanderPoint.Normalize();
            WanderPoint.Multiply(DistanceToWanderPoint);
            WanderPoint.Add(ME.Position);

            /* Create randomness to the movement. */
            double x = Math.Cos(randomValue) * WanderRadius;
            double y = Math.Sin(randomValue) * WanderRadius;
            WanderPoint.Add(new Vector2D(x, y));

            /* Determine the next value that determines the direction */
            Random r = new();
            if (r.Next(2) == 0) randomValue += 0.2; else randomValue += -0.2;

            /* Calculate Velocity. 
             * By subtracting the position of the WanderPoint by the position of the Entity 
             * And speed up the velocity to the maximum speed by Entity
             */
            return WanderPoint.Subtract(ME.Position).Normalize().Multiply(ME.MaxSpeed);




        }
    }
}
