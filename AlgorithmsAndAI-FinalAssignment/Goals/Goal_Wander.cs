using FinalAssignmentAAI.Common.Behaviour;
using FinalAssignmentAAI.Common.Steering;
using FinalAssignmentAAI.Common.Steering.Behaviours;
using FinalAssignmentAAI.Entities;

namespace FinalAssignmentAAI.Goals
{
    public class Goal_Wander : Goal
    {
        public Goal_Wander(Villager robot) : base(robot) { }
        public override void Activate()
        {
            CurrentStatus = GoalStatus.Active;
            Performer.SB.Add(new WanderBehaviour(Performer));
        }
        public override GoalStatus Process()
        {
            if (CurrentStatus == GoalStatus.Inactive) Activate();
            
            return CurrentStatus;
        }
        public override void Terminate()
        {
            CurrentStatus = GoalStatus.Completed;
            Performer.SB.Clear();
        }
    }
}
