using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;
using AlgorithmsAndAI_FinalAssignment.Source.StaticEntities;
using System.Configuration;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class WorldBuilder
    {
        public static void GenerateMovingEntities(World world)
        {
            /* Adding shuttles which will bring cargo to locations */
            CargoShuttle CS1 = new(world, new Vector2D(1300, 600));
            CargoShuttle CS2 = new(world, new Vector2D(600, 1100));
            CargoShuttle CS3 = new(world, new Vector2D(100, 600));
            world.MovingEntities.AddRange(new List<MovingEntity> { CS1, CS2, CS3 });

            /* Adding a Normal shuttle which will wander around or will follow path */
            NormalShuttle NS1 = new(world, new Vector2D(125, 125));
            world.MainAgent = NS1;

        }
        public static void GenerateStaticEntities(World world)
        {
            /* Adding Locations */
            DeliveryStation DS1 = new(world, new Vector2D(450, 150));
            DeliveryStation DS2 = new(world, new Vector2D(1100, 1000));

            DeliveryStation DS3 = new(world, new Vector2D(1200, 300));
            DeliveryStation DS4 = new(world, new Vector2D(150, 800));
            DeliveryStation DS5 = new(world, new Vector2D(700, 600));

            world.StaticEntities.AddRange(new List<StaticEntity> { DS1, DS2, DS3, DS4, DS5 });

            CargoWarehouse CW1 = new(world, new Vector2D(700, 1000));
            CargoWarehouse CW2 = new(world, new Vector2D(250, 300));
            CargoWarehouse CW3 = new(world, new Vector2D(950, 400));

            PetrolStation PS1 = new(world, new Vector2D(300, 550));
            PetrolStation PS2 = new(world, new Vector2D(1100, 700));

            RepairStation RS1 = new(world, new Vector2D(700, 200));
            RepairStation RS2 = new(world, new Vector2D(600, 900));


            world.StaticEntities.AddRange(new List<StaticEntity> { CW1, CW2, CW3, PS1, PS2, RS1, RS2 });


            List<Bitmap> Asteroids = new() { Resources.asteroid, Resources.asteroid2, Resources.asteroid3, Resources.asteroid4, Resources.asteroid5, Resources.asteroid6 };
            List<Bitmap> Planets = new() { Resources.crystal, Resources.icy, Resources.terrestrial, Resources.hot, Resources.radiated, Resources.earth, Resources.neptune };

            /* Adding some Astroids */
            world.StaticEntities.AddRange(new List<StaticEntity>
            {
                    new SpaceObstacle(world, new Vector2D(800, 950), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(700, 300), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(900, 600), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(200, 700), Asteroids[new Random().Next(Asteroids.Count)]),
            });

            /* Adding some Planets */
            world.StaticEntities.AddRange(new List<StaticEntity>
            {
                    new SpaceObstacle(world, new Vector2D(1000, 150), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(500, 300), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(420, 640), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(1050, 900), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(1100, 500), Planets[new Random().Next(Planets.Count)]),
                    new SpaceObstacle(world, new Vector2D(400, 900), Planets[new Random().Next(Planets.Count)]),

            });


        }
        /// <summary>
        /// Method to create the FuzzyModule with all the needed components.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public static FuzzyModule SetupBestCargoModule(World world)
        {
            FuzzyModule FM = new();

            /* Create Variables with their FuzzyTerm_SET's which are based on App.config data */
            FuzzyVariable Distance = FM.CreateFLV("DISTANCE");
            int DistanceMin = GetVariableValue("DistanceMin");
            int DistanceMid = GetVariableValue("DistanceMid");
            int DistanceMax = GetVariableValue("DistanceMax");
            FuzzyTerm_SET ShortDistance = Distance.AddLeftShoulderSet("SHORT", DistanceMin, DistanceMid / 2, DistanceMid);
            FuzzyTerm_SET MediumDistance = Distance.AddTriangle("MEDIUM", DistanceMid / 2, DistanceMid, DistanceMid / 2 * 3);
            FuzzyTerm_SET FarDistance = Distance.AddRightShoulderSet("FAR", DistanceMid, DistanceMid / 2 * 3, DistanceMax);

            FuzzyVariable Wear = FM.CreateFLV("WEAR");
            int WearMin = GetVariableValue("WearMin");
            int WearMid = GetVariableValue("WearMid");
            int WearMax = GetVariableValue("WearMax");
            FuzzyTerm_SET LowWear = Wear.AddLeftShoulderSet("LOW", WearMin, WearMid / 2, WearMid);
            FuzzyTerm_SET MediumWear = Wear.AddTriangle("MEDIUM", WearMid / 2, WearMid, WearMid / 2 * 3);
            FuzzyTerm_SET HighWear = Wear.AddRightShoulderSet("HIGH", WearMid, WearMid / 2 * 3, WearMax);

            FuzzyVariable Fuel = FM.CreateFLV("FUEL");
            int FuelMin = GetVariableValue("FuelMin");
            int FuelMid = GetVariableValue("FuelMid");
            int FuelMax = GetVariableValue("FuelMax");
            FuzzyTerm_SET LowFuel = Fuel.AddLeftShoulderSet("LOW", FuelMin, FuelMid / 2, FuelMid);
            FuzzyTerm_SET MediumFuel = Fuel.AddTriangle("MEDIUM", FuelMid / 2, FuelMid, FuelMid / 2 * 3);
            FuzzyTerm_SET HighFuel = Fuel.AddRightShoulderSet("HIGH", FuelMid, FuelMid / 2 * 3, FuelMax);

            FuzzyVariable Desirability = FM.CreateFLV("DESIRABILITY");
            int DesirabilityMin = GetVariableValue("DesirabilityMin");
            int DesirabilityMid = GetVariableValue("DesirabilityMid");
            int DesirabilityMax = GetVariableValue("DesirabilityMax");
            FuzzyTerm_SET Undesirable = Desirability.AddLeftShoulderSet("LOW", DesirabilityMin, DesirabilityMid / 2, DesirabilityMid);
            FuzzyTerm_SET Desirable = Desirability.AddTriangle("MEDIUM", DesirabilityMid / 2, DesirabilityMid, DesirabilityMid / 2 * 3);
            FuzzyTerm_SET VeryDesirable = Desirability.AddRightShoulderSet("HIGH", DesirabilityMid, DesirabilityMid / 2 * 3, DesirabilityMax);

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
        /// <summary>
        /// A method to get easily a value of a variable in the App.Config
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private static int GetVariableValue(string variable)
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get(variable));

        }

    }
}
