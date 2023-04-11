using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /* OccupationState of a Location. This really helps the simulation by knowing when a location is open or not. */
    public enum OccupationState
    {
        Open,
        Claimed,
        Occupied
    }

    public abstract class InteractiveLocation : StaticEntity
    {
        /* The Entity that has occupied this location */
        private MovingEntity? OccupiedBy;

        /* The state of a location: Open, Claimed or Occupied */
        private OccupationState occupationState;
        public InteractiveLocation(World world, Vector2D position) : base(world, position)
        {
            OccupiedBy = null;
            occupationState = OccupationState.Open;
            radius = 45;
        }

        /// <summary>
        /// A method to get the private OccupationState of the Location
        /// </summary>
        /// <returns></returns>
        public OccupationState GetOccupationState() { return occupationState; }

        /// <summary>
        /// Method to interact with the location when arrived
        /// </summary
        public void Claim(MovingEntity ME)
        {
            if (occupationState == OccupationState.Open)
            {
                OccupiedBy = ME;
                occupationState = OccupationState.Claimed;
            }
        }
        public override void Render(Graphics g)
        {
            if (Form1.LocationDetails) { g.DrawString("Occupied:" + GetOccupationState(), new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 30); }
        }

        public virtual void Interact(MovingEntity ME)
        {
            occupationState = OccupationState.Occupied;
        }

        /// <summary>
        /// Method to reset the location when a MovingEntity leaves the location.
        /// </summary>
        public void Leave()
        {
            OccupiedBy = null;
            occupationState = OccupationState.Open;
        }
        /// <summary>
        /// Method to check if this location is occupied by someone.
        /// </summary>
        /// <returns></returns>
        public bool IsOccupied()
        {
            return OccupiedBy != null && occupationState != OccupationState.Open;
        }

        /// <summary>
        /// Method to occupy a location when possible
        /// </summary>
        /// <param name="ME"></param>
        public void Occupy(MovingEntity ME)
        {
            OccupiedBy ??= ME;
        }


    }
}
