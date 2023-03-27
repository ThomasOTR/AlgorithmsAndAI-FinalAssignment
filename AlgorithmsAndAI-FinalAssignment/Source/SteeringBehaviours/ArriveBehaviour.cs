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
            if (ME.Target != null)
            {
                Vector2D toTarget = ME.Target.Clone().Subtract(ME.Position);
                if (toTarget == null) return new Vector2D();

                double distance = toTarget.Length();
                if (distance <= 0)
                {
                    return new Vector2D(0, 0);
                }

                double speed = ME.MaxSpeed;
                if (ME.Position.WithinRange(ME.Target, 100)) speed = (distance / 100) * ME.MaxSpeed;
                Vector2D desiredVelocity = toTarget.Multiply(speed).Divide(distance);

                return desiredVelocity.Subtract(ME.Velocity);
            }
            else return new Vector2D();
        }
        private static double Map(double value, double stop1, double stop2)
        {
            return (value / stop1) * stop2;
        }
    }
}
