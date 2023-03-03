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
                return desiredVelocity.Subtract(ME.Velocity);
            }
            return force.Negative();
        }
    }
}
