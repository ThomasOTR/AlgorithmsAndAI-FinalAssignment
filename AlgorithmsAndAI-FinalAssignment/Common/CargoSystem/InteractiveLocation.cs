using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    public abstract class InteractiveLocation : StaticEntity
    {
        /* The Entity that has occupied this location */
        private MovingEntity? OccupiedBy;

        /* This property is needed so shuttles will claim a location to let not others go to that location too. */
        public bool Claimed;
        public InteractiveLocation(World world, Vector2D position) : base(world, position)
        {
            OccupiedBy = null;
        }

        /// <summary>
        /// Method to interact with the location when arrived
        /// </summary>
        public abstract void Interact(MovingEntity ME);

        /// <summary>
        /// Method to check if this location is occupied by someone.
        /// </summary>
        /// <returns></returns>
        public bool IsOccupied()
        {
            return OccupiedBy != null;
        }

        /// <summary>
        /// Method to occupy a location when possible
        /// </summary>
        /// <param name="ME"></param>
        public void Occupy(MovingEntity ME)
        {
            if (OccupiedBy == null)
            {
                OccupiedBy = ME;
            }
        }
    }
}
