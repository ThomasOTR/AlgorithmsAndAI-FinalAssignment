using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System.Diagnostics;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
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

        private OccupationState occupationState;
        public InteractiveLocation(World world, Vector2D position) : base(world, position)
        {
            OccupiedBy = null;
            occupationState = OccupationState.Open;
            radius = 45;
        }

        public OccupationState GetOccupationState() { return occupationState; }
        /// <summary>
        /// Method to interact with the location when arrived
        /// </summary>

        public void Claim(MovingEntity ME)
        {
            if (occupationState == OccupationState.Open)
            {
                OccupiedBy = ME;
                occupationState = OccupationState.Claimed;
            }
            else
            {
                Debug.WriteLine("");
            }
        }
        public MovingEntity? GetOccupiedBy()
        {
            return OccupiedBy;
        }
        public virtual void Interact(MovingEntity ME)
        {
            occupationState = OccupationState.Occupied;
        }

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
            if (OccupiedBy == null)
            {
                OccupiedBy = ME;
            }
        }


    }
}
