using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class WanderBehaviour : SteeringBehaviour
    {
        const double DistanceToWanderPoint = 80;
        const double WanderRadius = 30;
        double theta = 20;
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
            double x = Math.Cos(theta) * WanderRadius;
            double y = Math.Sin(theta) * WanderRadius;
            WanderPoint.Add(new Vector2D(x, y));
            //WanderPoint.Add(new Vector2D(theta * 5, theta * 10));

            Random r = new();
            if (r.Next(2) == 0) theta += 0.2; else theta += -0.2;
            return WanderPoint.Subtract(ME.Position).Normalize().Multiply(ME.MaxSpeed);




        }
    }
}
