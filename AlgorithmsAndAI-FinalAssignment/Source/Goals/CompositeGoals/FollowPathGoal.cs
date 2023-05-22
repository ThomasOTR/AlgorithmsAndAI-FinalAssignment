using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace FinalAssignmentAAI.Goals
{
    /// <summary>
    /// This goal will get the calculated path by Astar and willl seek to each point.
    /// </summary>
    public class FollowPathGoal : CompositeGoal
    {
        public FollowPathGoal(MovingEntity ME) : base(ME)
        {

        }
        public override void Activate()
        {
            /* Activate the goal */
            base.Activate();

            /* Create goals based on the planned path */
            CreateGoalsOfPath(Performer.world.graph.GetShortestPath());
        }

        /// <summary>
        /// A method to create Seek goals of the path;
        /// </summary>
        /// <param name="path"></param>
        private void CreateGoalsOfPath(List<Node> path)
        {
            if (path.Count == 0) Status = GoalStatus.Failed;

            foreach (Node node in path)
            {
                /* If the current node position is the same as the Performer. Skip adding a goal, so it will not do goals for nothing */
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
            /* This is needed to reuse the graph */
            Performer.world.graph.Reset();

            /* Terminate a goal as usual */
            base.Terminate();

        }
    }
}
