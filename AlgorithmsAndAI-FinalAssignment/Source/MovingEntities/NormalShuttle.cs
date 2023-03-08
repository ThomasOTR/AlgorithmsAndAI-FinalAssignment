using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// A normal shuttle that will follow the shortest
    /// </summary>
    public class NormalShuttle : MovingEntity
    {
        public NormalShuttle(World world, Vector2D position, Vector2D TargetPosition) : base(world, position, TargetPosition) { }
        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
