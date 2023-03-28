using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    public class ReceiveNewCargoGoal : CompositeGoal
    {
        private CargoWarehouse? CW;
        public ReceiveNewCargoGoal(MovingEntity ME) : base(ME)
        {
            /* If there is no cargo, nothing can be delivered*/
            if (Performer.cargo != null) Status = GoalStatus.Failed;
            else
            {
                /* Get nearest available warehouse */
                CW = GetNearestWarehouse();

                /* If there is no available warehouse, the goal is failed*/
                if (CW == null) Status = GoalStatus.Failed;
                else
                {
                    /* Claim the warehouse and add the goals in opposite order*/
                    CW.Claim(Performer);
                    Subgoals.Push(new GetCargoGoal(Performer, CW));
                    Subgoals.Push(new ArriveGoal(Performer, CW.Position));
                }
            }
        }

        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        public override void Terminate()
        {
            /* Leave the warehouse so others can go to it */
            CW?.Leave();

            /* Terminate the goal as usual */
            base.Terminate();

        }

        /// <summary>
        /// This method will find the nearest warehouse to receive a new package
        /// </summary>
        /// <returns></returns>
        private CargoWarehouse? GetNearestWarehouse()
        {
            /* Get all the warehouses available */
            List<CargoWarehouse> warehouses = Performer.world.GetStaticEntityListOf<CargoWarehouse>();

            if (warehouses.Count != 0)
            {
                CargoWarehouse? NearestCW = null;
                double distanceToNearest = float.PositiveInfinity;

                /* Loop through all the warehouses */
                foreach (CargoWarehouse warehouse in warehouses)
                {
                    /* if a warehouse is occupied, skip it */
                    if (warehouse.IsOccupied()) continue;

                    /* if the distance to the warehouse is closer than the closest one before. Add it to the variables */
                    double nearest = Performer.Position.Distance(warehouse.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestCW = warehouse;
                        distanceToNearest = nearest;
                    }
                }
                return NearestCW;
            }
            return null;
        }
    }
}
