using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class BaseGameEntity
    {
        /* Identifier to know which Entity is which */
        public int ID;

        /* A property to determine the next ID */
        private static int NextID = 0;

        /* The position of the Entity. This is an important property */
        public Vector2D Position;

        /* The World where this Entity lives in. This is used to access specific world things */
        public World world;
        public BaseGameEntity(World world, Vector2D Position)
        {
            ID = NextID;
            NextID++;
            this.world = world;
            this.Position = Position;
        }

        /// <summary>
        /// Method to update the Entity. This will be triggered by the World update method.
        /// </summary>
        /// <param name="delta"></param>
        public abstract void Update(float delta);

    }
}
