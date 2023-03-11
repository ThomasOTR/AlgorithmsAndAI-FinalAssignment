using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    public class GoRepairGoal : CompositeGoal
    {
        public GoRepairGoal(MovingEntity ME) : base(ME)
        {
        }
        public override void Activate()
        {
            base.Activate();

            RepairStation RS = GetNearestRepairStation();

            Subgoals.Push(new RepairGoal(Performer, RS));
            Subgoals.Push(new ArriveGoal(Performer, RS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        private RepairStation GetNearestRepairStation()
        {
            return new RepairStation(Performer.world, new Vector2D(), 2);
        }
    }
}
