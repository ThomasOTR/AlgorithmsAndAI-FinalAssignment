using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
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

        public override void Interact(MovingEntity shuttle)
        {
            /* The shuttle will get the cargo that suits the best by it's situation. */

            if (shuttle.cargo != null) return;
            shuttle.cargo = GetCargoSuitedBestForShuttle();
        }
        public Cargo GetCargoSuitedBestForShuttle()
        {
            // Implement Fuzzy Logic

            var list = world.GetStaticEntityListOf<DeliveryStation>();
            Random r = new Random();
            return new Cargo("Name", list[r.Next(list.Count)]);
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - radius), radius * 2, radius * 2);
            g.FillRectangle(Brushes.Green, r);
            g.DrawString("Warehouse", new Font("Arial", 6), Brushes.Black, (int)Position.x - radius - 10, (int)Position.y + radius + 5);
        }
    }
}
