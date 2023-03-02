using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Steering
{
    public abstract class SteeringBehaviour
    {
        public MovingEntity ME { get; set; }
        public abstract Vector2D Calculate();
        public SteeringBehaviour(MovingEntity ME)
        {
            this.ME = ME;
        }
    }
}
