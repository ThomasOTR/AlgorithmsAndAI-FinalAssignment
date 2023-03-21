using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;
using AlgorithmsAndAI_FinalAssignment.Source.StaticEntities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class WorldBuilder
    {
        public static void GenerateMovingEntities(World world)
        {
            CargoShuttle CS1 = new(world, new Vector2D(125, 125));
            world.MovingEntities.AddRange(new List<MovingEntity> { CS1 });
            NormalShuttle NS1 = new(world, new Vector2D(125, 125));

            world.MainAgent = NS1;

        }
        public static void GenerateStaticEntities(World world)
        {
            DeliveryStation DS1 = new(world, new Vector2D(400, 300));
            DeliveryStation DS2 = new(world, new Vector2D(200, 400));

            world.StaticEntities.Add(DS1);
            world.StaticEntities.Add(DS2);


            CargoWarehouse CW1 = new(world, new Vector2D(700, 850));
            CargoWarehouse CW2 = new(world, new Vector2D(1000, 300));


            PetrolStation PS1 = new(world, new Vector2D(600, 600));
            PetrolStation PS2 = new(world, new Vector2D(900, 100));

            RepairStation RS1 = new(world, new Vector2D(500, 1000));
            RepairStation RS2 = new(world, new Vector2D(100, 400));
            world.StaticEntities.AddRange(new List<StaticEntity> { CW1, CW2, PS1, PS2, RS1, RS2 });

            List<Bitmap> Asteroids = new() { Resources.asteroid, Resources.asteroid2, Resources.asteroid3, Resources.asteroid4, Resources.asteroid5, Resources.asteroid6 };
            List<Bitmap> Planets = new() { Resources.crystal, Resources.icy, Resources.terrestrial, Resources.hot, Resources.radiated, Resources.earth, Resources.neptune };
            world.StaticEntities.AddRange(new List<StaticEntity>
            {
                    new SpaceObstacle(world, new Vector2D(400, 950), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(700, 300), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(500, 45), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(200, 1100), Asteroids[new Random().Next(Asteroids.Count)]),
            });

            world.StaticEntities.AddRange(new List<StaticEntity>
            {
            //        new SpaceObstacle(world, new Vector2D(900, 300), Planets[new Random().Next(Planets.Count)], 30),
                    new SpaceObstacle(world, new Vector2D(100, 300), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(420, 640), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(400, 200), Planets[new Random().Next(Planets.Count)]),
            });


        }
        public static FuzzyModule SetupBestCargoModule(World world)
        {

            double MaximalDistance = new Vector2D(0, 0).DistanceSquared(new Vector2D(world.Width, world.Height));

            //int distanceLow = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DistanceLow"));
            //int distanceMid = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DistanceMid"));
            //int distanceHigh = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DistanceHigh"));

            FuzzyModule FM = new();

            /* Create Variables */
            FuzzyVariable Distance = FM.CreateFLV("DISTANCE");
            FuzzyTerm_SET ShortDistance = Distance.AddLeftShoulderSet("LOW", 0, MaximalDistance / 4, MaximalDistance / 2);
            FuzzyTerm_SET MediumDistance = Distance.AddTriangle("MEDIUM", MaximalDistance / 4, MaximalDistance / 2, MaximalDistance / 4 * 3);
            FuzzyTerm_SET FarDistance = Distance.AddRightShoulderSet("HIGH", MaximalDistance / 2, MaximalDistance / 4 * 3, MaximalDistance);

            FuzzyVariable Wear = FM.CreateFLV("WEAR");
            FuzzyTerm_SET LowWear = Wear.AddLeftShoulderSet("LOW", 0, 25, 50);
            FuzzyTerm_SET MediumWear = Wear.AddTriangle("MEDIUM", 25, 50, 75);
            FuzzyTerm_SET HighWear = Wear.AddRightShoulderSet("HIGH", 50, 75, 100);

            FuzzyVariable Fuel = FM.CreateFLV("FUEL");
            FuzzyTerm_SET LowFuel = Fuel.AddLeftShoulderSet("LOW", 0, 25, 50);
            FuzzyTerm_SET MediumFuel = Fuel.AddTriangle("MEDIUM", 25, 50, 75);
            FuzzyTerm_SET HighFuel = Fuel.AddRightShoulderSet("HIGH", 50, 75, 100);

            FuzzyVariable Desirability = FM.CreateFLV("DESIRABILITY");
            FuzzyTerm_SET Undesirable = Desirability.AddLeftShoulderSet("Undesirable", 0, 25, 50);
            FuzzyTerm_SET Desirable = Desirability.AddTriangle("Desirable", 25, 50, 75);
            FuzzyTerm_SET VeryDesirable = Desirability.AddRightShoulderSet("VeryDesirable", 50, 75, 100);

            /* Undesirable Rules*/
            FM.AddRule(new FuzzyTerm_AND(FarDistance, LowWear, LowFuel), Undesirable);
            FM.AddRule(new FuzzyTerm_AND(FarDistance, LowWear, MediumFuel), Undesirable);
            FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, LowFuel), Undesirable);

            FM.AddRule(new FuzzyTerm_AND(MediumDistance, HighWear, HighFuel), Undesirable);

            FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, HighFuel), Undesirable);
            FM.AddRule(new FuzzyTerm_AND(ShortDistance, HighWear, MediumFuel), Undesirable);
            FM.AddRule(new FuzzyTerm_AND(ShortDistance, HighWear, HighWear), Undesirable);

            /* Desirable Rules*/
            FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, MediumFuel), Desirable);

            FM.AddRule(new FuzzyTerm_AND(MediumDistance, LowWear, MediumFuel), Desirable);
            FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, LowFuel), Desirable);
            FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, HighFuel), Desirable);
            FM.AddRule(new FuzzyTerm_AND(MediumDistance, HighWear, MediumFuel), Desirable);

            FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, MediumFuel), Desirable);

            /* Very Desirable Rules*/
            FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, HighFuel), VeryDesirable);
            FM.AddRule(new FuzzyTerm_AND(FarDistance, HighWear, MediumFuel), VeryDesirable);
            FM.AddRule(new FuzzyTerm_AND(FarDistance, HighWear, HighFuel), VeryDesirable);

            FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, MediumFuel), VeryDesirable);

            FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, LowFuel), VeryDesirable);
            FM.AddRule(new FuzzyTerm_AND(ShortDistance, LowWear, MediumFuel), VeryDesirable);
            FM.AddRule(new FuzzyTerm_AND(ShortDistance, LowWear, LowFuel), VeryDesirable);

            return FM;

        }

    }
}
