using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Goals;

namespace FinalAssignmentAAI.Goals
{
    public class FollowPathGoal : CompositeGoal
    {
        public FollowPathGoal(MovingEntity ME) : base(ME)
        {

        }
        public override void Activate()
        {
            base.Activate();
            CreateGoalsOfPath(Performer.world.graph.GetShortestPath());
        }
        private void CreateGoalsOfPath(List<Node> path)
        {
            path.Reverse();
            foreach (Node node in path)
            {
                if (Performer.Position.Equals(node.Position)) continue;

                Subgoals.Push(new SeekGoal(Performer, node.Position));
            }
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        public override void Terminate()
        {
            Performer.world.graph.Reset();
        }
    }
}
