using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class ArriveBehaviour : SteeringBehaviour
    {
        public ArriveBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D force = new Vector2D();
            if (ME.Target != null)
            {
                Vector2D VectorToTarget = ME.Target.Position.Clone().Subtract(ME.Position);

                if (VectorToTarget.Length() > 0)
                {
                    double speed = VectorToTarget.Length() / 5;
                    speed = Math.Min(speed, ME.MaxSpeed);
                    Vector2D desiredVelocity = VectorToTarget.Multiply(speed).Divide(VectorToTarget.Length());

                    force = desiredVelocity.Subtract(ME.Velocity);
                }
            }
            return force;
        }
    }
}
