using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// The main entity that will be perform goals by steering and logic.
    /// </summary>
    public class CargoShuttle : MovingEntity
    {
        /* Cargo of this shuttle. This will be filled at a CargoWarehouse and will be emptied by a DeliveryStation. */
        public Cargo? cargo;

        /* Statistic of the Shuttle. This will be decreased over time when travelling. This can be increased at Petrol Stations */
        public Statistic Fuel;

        /* Statistic of the SHuttle. This will be decreased over time when travelling. This can be increased at Repair Stations */
        public Statistic Wear;
        public CargoShuttle(World world, Vector2D Position, Vector2D Target) : base(world, Position, Target)
        {
            Fuel = new Statistic(100);
            Wear = new Statistic(100);
        }

        /// <summary>
        /// Method to load the ship with cargo.
        /// </summary>
        /// <param name="cargo"></param>
        public void AddCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
