using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class WorldBuilder
    {
        public static void GenerateMovingEntities(World world)
        {
            CargoShuttle CS1 = new(world, new Vector2D(125, 125));
            CS1.Target = new Vector2D(500, 500);
            CS1.SteeringBehaviours.Add(new WanderBehaviour(CS1));

            world.MovingEntities.AddRange(new List<MovingEntity> { CS1 });

        }
        public static void GenerateStaticEntities(World world)
        {

            CargoWarehouse CW1 = new(world, new Vector2D(700, 812.5));

            world.StaticEntities.AddRange(new List<StaticEntity> { CW1 });

        }

    }
}
