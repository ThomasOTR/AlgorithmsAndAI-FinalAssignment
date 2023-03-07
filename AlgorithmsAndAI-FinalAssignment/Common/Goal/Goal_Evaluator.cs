using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Goal
{
    public abstract class Goal_Evaluator
    {
        public abstract double CalculateDesirability(MovingEntity ME);
        public abstract void SetGoal(MovingEntity ME);
    }
}
