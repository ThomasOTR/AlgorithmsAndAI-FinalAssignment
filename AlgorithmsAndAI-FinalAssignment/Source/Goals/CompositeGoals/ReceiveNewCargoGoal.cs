using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    public class ReceiveNewCargoGoal : CompositeGoal
    {
        private CargoWarehouse CW;
        public ReceiveNewCargoGoal(MovingEntity movingEntity) : base(movingEntity)
        {
            CW = GetNearestWarehouse();

            Subgoals.Push(new GetCargoGoal(Performer, CW));
            Subgoals.Push(new ArriveGoal(Performer, CW.Position));
        }

        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        /// <summary>
        /// This method will find the nearest warehouse to receive a new package
        /// </summary>
        /// <returns></returns>
        private CargoWarehouse GetNearestWarehouse()
        {
            List<CargoWarehouse> warehouses = Performer.world.GetStaticEntityListOf<CargoWarehouse>();

            if (warehouses.Count == 0)
            {
                CargoWarehouse CW = new CargoWarehouse(Performer.world, new Vector2D(500, 100));
                Performer.world.StaticEntities.Add(CW);
                return CW;
            }
            else
            {
                CargoWarehouse NearestCW = new CargoWarehouse(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;
                foreach (CargoWarehouse warehouse in warehouses)
                {
                    double nearest = Performer.Position.Distance(warehouse.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestCW = warehouse;
                        distanceToNearest = nearest;
                    }
                }
                return NearestCW;
            }
        }
    }
}
