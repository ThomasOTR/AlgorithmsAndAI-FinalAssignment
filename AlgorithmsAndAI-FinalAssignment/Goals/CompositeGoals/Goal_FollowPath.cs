using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Goals;

namespace FinalAssignmentAAI.Goals
{
    public class Goal_FollowPath : CompositeGoal
    {
        public Goal_FollowPath(MovingEntity ME) : base(ME)
        {

        }
        public override void Activate()
        {
            base.Activate();
            CreateGoalsOfPath(Performer.world.graph.GetShortestPath());
        }
        private void CreateGoalsOfPath(List<Node> path)
        {
            foreach (Node node in path) 
            {
                if (Performer.Position.Equals(node.Position)) continue;

                Subgoals.Push(new SeekGoal(Performer, node.Position));
            }
        }
        public override GoalStatus Process()
        {
            return base.ProcessSubgoals();
        }
        public override void Terminate()
        {
            NavigationGraph graph = Performer.world.graph;
            foreach (Node n in graph.GetShortestPath()) n.Reset();
            graph.GetVisitedNodes().Clear();

        }
    }
}
