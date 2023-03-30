using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;

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
            /* Triggers the default method which will update the Occuptation state */
            base.Interact(shuttle);

            /* If the shuttle has cargo, do nothing. */
            if (shuttle.cargo != null) return;

            /* The shuttle will get the cargo that suits the best by it's situation. */
            Cargo? cargo = GetCargoSuitedBestForShuttle(shuttle);
            if (cargo != null) shuttle.cargo = cargo;
        }
        public override void Update(float delta)
        {
            base.Update(delta);

            if (CargoForDelivery.Count < 5) CreateNewCargo();

        }
        private void CreateNewCargo()
        {
            List<DeliveryStation> stations = world.GetStaticEntityListOf<DeliveryStation>();
            Random r = new();

            /* Create a cargo with pre-defined names and already existing locations. */
            Cargo c = new(
                           Name: Cargo.CargoNames[r.Next(Cargo.CargoNames.Length - 1)],
                           targetLocation: stations[r.Next(stations.Count)]);
            CargoForDelivery.Add(c);
        }

        /// <summary>
        /// A method to determine the best cargo. This is done with FuzzyLogic.
        /// </summary>
        /// <param name="ME"></param>
        /// <returns></returns>
        public Cargo? GetCargoSuitedBestForShuttle(MovingEntity ME)
        {
            Cargo? MostDesirableCargo = null;
            double HighestDesirabililtyValue = 0.0;

            foreach (Cargo cargo in CargoForDelivery)
            {
                /* Checks to improve the cargo delivery cyclus */
                if (cargo.TargetLocation == null) continue;
                else if (cargo.TargetLocation.GetOccupationState() == OccupationState.Claimed
                || cargo.TargetLocation.GetOccupationState() == OccupationState.Occupied) continue;

                /* Get the current state of the Fuzzy Logic variables. */
                double fuel = ME.Fuel.currentValue;
                double wear = ME.Wear.currentValue;
                double distance = ME.Position.DistanceSquared(cargo.TargetLocation.Position);

                FuzzyModule fm = ME.world.BestCargoModule;

                /* Fuzzyify all the variables with the current values */
                fm.Fuzzify("WEAR", wear);
                fm.Fuzzify("FUEL", fuel);
                fm.Fuzzify("DISTANCE", distance);
                /* Defuzzify and check if it is a higher Desirability.*/
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
            Rectangle r = new((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            g.DrawImage(Resources.CargoWarehouse, r);
            g.DrawString("Warehouse", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);

            base.Render(g);



        }
    }
}
