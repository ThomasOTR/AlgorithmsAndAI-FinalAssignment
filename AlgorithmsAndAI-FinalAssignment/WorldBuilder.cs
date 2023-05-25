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
            CargoShuttle CS2 = new(world, new Vector2D(800, 300));
            CargoShuttle CS3 = new(world, new Vector2D(500, 1000));
            world.MovingEntities.AddRange(new List<MovingEntity> { CS1, CS2, CS3 });

            /* Adding a Normal shuttle which will wander around or will follow path */
            NormalShuttle NS1 = new(world, new Vector2D(125, 125));
            world.MainAgent = NS1;

        }
        public static void GenerateStaticEntities(World world)
        {
            /* Adding Locations */
            DeliveryStation DS1 = new(world, new Vector2D(250, 250));
            DeliveryStation DS2 = new(world, new Vector2D(1500, 750));

            DeliveryStation DS3 = new(world, new Vector2D(1300, 200));
            DeliveryStation DS4 = new(world, new Vector2D(300, 800));
            DeliveryStation DS5 = new(world, new Vector2D(850, 500));

            /* Adding the DeliveryStations first (This is needed because otherwise the warehouse cannot be filled with cargo with their destination */
            world.StaticEntities.AddRange(new List<StaticEntity> { DS1, DS2, DS3, DS4, DS5 });


            ///* Adding the rest of the locations */
            CargoWarehouse CW1 = new(world, new Vector2D(550, 850));
            CargoWarehouse CW2 = new(world, new Vector2D(550, 350));
            CargoWarehouse CW3 = new(world, new Vector2D(1200, 450));
            CargoWarehouse CW4 = new(world, new Vector2D(1200, 1000));

            FuelStation FS1 = new(world, new Vector2D(550, 600));
            FuelStation FS2 = new(world, new Vector2D(1200, 800));
            FuelStation FS3 = new(world, new Vector2D(850, 250));

            RepairStation RS1 = new(world, new Vector2D(150, 500));
            RepairStation RS2 = new(world, new Vector2D(900, 650));
            RepairStation RS3 = new(world, new Vector2D(1550, 400));

            world.StaticEntities.AddRange(new List<StaticEntity> { CW1, CW2, CW3, CW4, FS1, FS2, FS3, RS1, RS2, RS3 });


            List<Bitmap> Asteroids = new() { Resources.asteroid1, Resources.asteroid2, Resources.asteroid3, Resources.asteroid4, Resources.asteroid5, Resources.asteroid6 };
            List<Bitmap> Planets = new() { Resources.crystal, Resources.icy, Resources.terrestrial, Resources.hot, Resources.radiated, Resources.earth, Resources.neptune };

            /* Adding some Astroids */
            world.StaticEntities.AddRange(new List<StaticEntity>
            {
                    new SpaceObstacle(world, new Vector2D(850, 800), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(750, 400), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(1050, 600), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(200, 700), Asteroids[new Random().Next(Asteroids.Count)]),
                    new SpaceObstacle(world, new Vector2D(1450, 250), Asteroids[new Random().Next(Asteroids.Count)]),

            });

            /* Adding some Planets */
            world.StaticEntities.AddRange(new List<StaticEntity>
            {
                new SpaceObstacle(world, new Vector2D(500, 150), Planets[new Random().Next(Planets.Count)]),
                new SpaceObstacle(world, new Vector2D(350,400), Planets[new Random().Next(Planets.Count)]),
                new SpaceObstacle(world, new Vector2D(1350, 700), Planets[new Random().Next(Planets.Count)]),
                new SpaceObstacle(world, new Vector2D(1150, 250), Planets[new Random().Next(Planets.Count)]),
                new SpaceObstacle(world, new Vector2D(700, 1000), Planets[new Random().Next(Planets.Count)]),
                new SpaceObstacle(world, new Vector2D(100, 900), Planets[new Random().Next(Planets.Count)]),

            });




        }
        /// <summary>
        /// Method to create the FuzzyModule with all the needed components.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public static FuzzyModule? SetupBestCargoModule()
        {
            if (File.Exists("AlgorithmsAndAI_FinalAssignment.dll.config"))
            {
                Form1.ConfigurationFileLoadedIn = true;
                FuzzyModule FM = new();

                /* Create Variables with their FuzzyTerm_SET's which are based on the data from the config file */
                FuzzyVariable Distance = FM.CreateFLV("DISTANCE");
                int DistanceMin = GetVariableValue("DistanceMin");
                int DistanceMid = GetVariableValue("DistanceMid");
                int DistanceMax = GetVariableValue("DistanceMax");
                FuzzyTerm_SET ShortDistance = Distance.AddLeftShoulderSet("SHORT", DistanceMin, DistanceMid / 2, DistanceMid);
                FuzzyTerm_SET MediumDistance = Distance.AddTriangle("MEDIUM", DistanceMid / 2, DistanceMid, DistanceMid * 3 / 2);
                FuzzyTerm_SET FarDistance = Distance.AddRightShoulderSet("FAR", DistanceMid, DistanceMid * 2, DistanceMax);

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

                /* Adding fuzzy rules*/
                FM.AddRule(new FuzzyTerm_AND(FarDistance, LowWear, LowFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, LowWear, MediumFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, LowWear, HighFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, LowFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, MediumFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, MediumWear, HighFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, HighWear, LowFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, HighWear, MediumFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(FarDistance, HighWear, HighFuel), VeryDesirable);

                FM.AddRule(new FuzzyTerm_AND(MediumDistance, LowWear, LowFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, LowWear, MediumFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, LowWear, HighFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, LowFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, MediumFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, MediumWear, HighFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, HighWear, LowFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, HighWear, MediumFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(MediumDistance, HighWear, HighFuel), Undesirable);

                FM.AddRule(new FuzzyTerm_AND(ShortDistance, LowWear, LowFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, LowWear, MediumFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, LowWear, HighFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, LowFuel), VeryDesirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, MediumFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, MediumWear, HighFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, HighWear, LowFuel), Desirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, HighWear, MediumFuel), Undesirable);
                FM.AddRule(new FuzzyTerm_AND(ShortDistance, HighWear, HighFuel), Undesirable);

                return FM;
            }
            else return null;
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
