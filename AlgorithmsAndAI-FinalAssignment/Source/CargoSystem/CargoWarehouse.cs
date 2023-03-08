using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    /// <summary>
    /// Class of the Warehouse with all the deliverable cargo. This is part of the Simulation.
    /// </summary>
    public class CargoWarehouse : InteractiveLocation
    {
        /* List with all the cargo that will be delivered by CargoShuttles. This List will be filled by an automatic system to keep the simulation running. */
        public List<Cargo> CargoForDelivery;
        public CargoWarehouse(World world, Vector2D position) : base(world, position)
        {
            CargoForDelivery = new List<Cargo>();
        }

        public override void Interact(CargoShuttle shuttle)
        {
            /* The shuttle will get the cargo that suits the best by it's situation. */

            if (shuttle.cargo != null) return;

            shuttle.AddCargo(CargoForDelivery.First());
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
