using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    public class GoRefuelGoal : CompositeGoal
    {
        public GoRefuelGoal(MovingEntity ME) : base(ME)
        {
        }
        public override void Activate()
        {
            base.Activate();

            PetrolStation PS = GetNearestRefuelStation();

            Subgoals.Push(new RefuelGoal(Performer, PS));
            Subgoals.Push(new ArriveGoal(Performer, PS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        private PetrolStation GetNearestRefuelStation()
        {
            return new PetrolStation(Performer.world, new Vector2D(), 2);
        }
    }
}
