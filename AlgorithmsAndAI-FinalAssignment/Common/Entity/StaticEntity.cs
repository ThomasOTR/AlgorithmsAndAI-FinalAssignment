using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class StaticEntity : BaseGameEntity
    {
        /* The radius of the Entity. This will be used in the render and the check if a node is in range of the Static Entity */
        public double radius = 10;
        public StaticEntity(World world, Vector2D position) : base(world, position) { }


        public override void Update(float delta)
        {

        }
        public abstract void Render(Graphics g);
    }
}
