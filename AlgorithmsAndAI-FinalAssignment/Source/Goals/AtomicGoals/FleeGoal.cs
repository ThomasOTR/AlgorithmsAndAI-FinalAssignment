﻿using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will start the Flee Behaviour */
    /// </summary>
    public class FleeGoal : Goal
    {
        /* The flee behaviour needs a target from where it fleeing. */
        private Vector2D targetFleeingFrom;
        public FleeGoal(MovingEntity ME, Vector2D Target) : base(ME)
        {
            targetFleeingFrom = Target;
        }
        public override void Activate()
        {
            /* This will update the status to Active */
            base.Activate();

            /* Add the flee behaviour and the target to our shuttle */
            Performer.Target = targetFleeingFrom;
            Performer.SteeringBehaviours.Add(new FleeBehaviour(Performer));
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* if the Peformer is a high distance away from the target 
             * the goal is completed
             */
            if (Performer.Target != null)
            {
                if (Performer.Position.Distance(Performer.Target) > 500) Status = GoalStatus.Completed;
            }
            else Status = GoalStatus.Failed;

            return Status;
        }
        public override void Terminate()
        {
            /* Reset the Velocity to a default vector to give the next behaviour a fresh start */
            Performer.Velocity = new Vector2D(0, 0);

            /* Remove the arrive steering behaviour from the steeringbehaviours list */
            Performer.SteeringBehaviours.RemoveAll(x => x is FleeBehaviour);

            base.Terminate();

        }
    }
}
