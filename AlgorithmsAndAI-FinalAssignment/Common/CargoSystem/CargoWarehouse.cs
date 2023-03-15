using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
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
            for (int i = 0; i <= 5; i++) CreateNewCargo();

        }

        public override void Interact(MovingEntity shuttle)
        {
            /* The shuttle will get the cargo that suits the best by it's situation. */

            if (shuttle.cargo != null) return;
            Cargo cargo = GetCargoSuitedBestForShuttle(shuttle);
            if (cargo != null) shuttle.cargo = cargo;
        }
        public override void Update(float delta)
        {
            base.Update(delta);

            if (CargoForDelivery.Count <= 5) CreateNewCargo();

        }
        private void CreateNewCargo()
        {
            List<DeliveryStation> stations = world.GetStaticEntityListOf<DeliveryStation>();
            Random r = new Random();
            Cargo c = new(
                           Name: Cargo.CargoNames[r.Next(Cargo.CargoNames.Length - 1)],
                           targetLocation: stations[r.Next(stations.Count)]);
            CargoForDelivery.Add(c);
        }
        public Cargo GetCargoSuitedBestForShuttle(MovingEntity ME)
        {
            // Implement Fuzzy Logic
            Cargo MostDesirableCargo = null;
            double HighestDesirabililtyValue = 0.0;

            foreach (Cargo cargo in CargoForDelivery)
            {
                if (cargo.TargetLocation == null) continue;

                double fuel = ME.Fuel.currentValue;
                double wear = ME.Wear.currentValue;
                double distance = ME.Position.Distance(cargo.TargetLocation.Position);

                FuzzyModule fm = ME.world.BestCargoModule;

                fm.Fuzzify("WEAR", wear);
                fm.Fuzzify("FUEL", fuel);
                fm.Fuzzify("DISTANCE", distance / 18);

                double DefuzzifiedValue = fm.Defuzzify("DESIRABILITY");
                if (DefuzzifiedValue > HighestDesirabililtyValue)
                {
                    MostDesirableCargo = cargo;
                    HighestDesirabililtyValue = DefuzzifiedValue;
                }

            }
            return MostDesirableCargo;
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - radius), radius * 2, radius * 2);
            g.FillRectangle(Brushes.Green, r);
            g.DrawString("Warehouse " + CargoForDelivery.Count, new Font("Arial", 6), Brushes.Black, (int)Position.x - radius - 10, (int)Position.y + radius + 5);

        }
    }
}
