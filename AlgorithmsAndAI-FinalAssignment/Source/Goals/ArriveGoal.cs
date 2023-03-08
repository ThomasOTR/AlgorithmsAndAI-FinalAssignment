using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Goals
{
    public class ArriveGoal : Goal
    {
        private Vector2D Target;
        public ArriveGoal(MovingEntity ME, Vector2D Target) : base(ME) 
        {
            this.Target = Target;
        }
        public override void Activate()
        {
            base.Activate();
            Performer.Target = Target;
            Performer.SteeringBehaviours.Add(new ArriveBehaviour(Performer));

        }
        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            if (Performer.Position.WithinRange(Performer.Target, 5)) Status = GoalStatus.Completed;

            return Status;
        }
        public override void Terminate()
        {
            Performer.Velocity = new Vector2D();
            Performer.SteeringBehaviours.Clear();
        }
    }
}
