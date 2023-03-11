using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// A normal shuttle that will follow the shortest
    /// </summary>
    public class NormalShuttle : MovingEntity
    {
        public NormalShuttle(World world, Vector2D position) : base(world, position)
        {
            Brain.AddEvaluator(new FollowPathEvaluator());
        }
        public override void Render(Graphics g)
        {
            Pen p = new(Color.Orange, 1);
            Rectangle r = new Rectangle((int)(Position.x - 20), (int)(Position.y - 20), 20, 20);
            g.DrawRectangle(p, r);
        }
    }
}
