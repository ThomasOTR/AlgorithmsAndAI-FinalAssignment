using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class BaseGameEntity
    {
        public int ID;
        private static int NextID = 0;
        public Vector2D Position;
        public World world;
        public BaseGameEntity(World world, Vector2D Position)
        {
            ID = NextID;
            NextID++;
            this.world = world;
            this.Position= Position;
        }
        public abstract void Update(float delta);
        public abstract void Render(Graphics g);

    }
}
