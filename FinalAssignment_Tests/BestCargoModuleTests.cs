using AlgorithmsAndAI_FinalAssignment;
using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace FinalAssignment_Tests
{
    public class BestCargoModuleTests
    {
        World world;
        [SetUp]
        public void Setup()
        {
            world = new World(width: 1400, height: 1200);
            world.StaticEntities.Clear();
            world.MovingEntities.Clear();
        }

        [Test]
        public void Test1()
        {

            CargoShuttle CS = new CargoShuttle(world, new Vector2D(100, 100));
            CS.Wear.currentValue = 25;
            CS.Fuel.currentValue = 25;
            world.MovingEntities.Add(CS);

            DeliveryStation DS1 = new DeliveryStation(world, new Vector2D(200, 200));
            DeliveryStation DS2 = new DeliveryStation(world, new Vector2D(700, 700));
            DeliveryStation DS3 = new DeliveryStation(world, new Vector2D(1300, 1100));
            world.StaticEntities.AddRange(new List<StaticEntity> { DS1, DS2, DS3 });


            CargoWarehouse cargoWarehouse = new CargoWarehouse(world, new Vector2D(100, 100));
            world.StaticEntities.Add(cargoWarehouse);

            cargoWarehouse.Interact(CS);
        }

    }
}
