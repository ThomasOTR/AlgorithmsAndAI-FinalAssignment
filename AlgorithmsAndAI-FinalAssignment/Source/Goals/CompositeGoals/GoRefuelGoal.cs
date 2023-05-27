using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    /// <summary>
    /// This goal will move the shuttle to a FuelStation and refuel the shuttle
    /// </summary>
    public class GoRefuelGoal : CompositeGoal
    {
        private FuelStation? FS;
        public GoRefuelGoal(MovingEntity ME) : base(ME)
        {
            FS = null;
        }
        public override void Activate()
        {
            /* Activate the goal */
            base.Activate();

            /* Get the nearest available refuel station */
            FS = GetNearestFuelStation();

            /* If there is no petrol station to go, this goal is failed*/
            if (FS == null) Status = GoalStatus.Failed;

            /* if there is one available, claim it and add the goals in opposite order*/
            else
            {
                FS.Claim(Performer);

                Subgoals.Push(new RefuelGoal(Performer, FS));
                Subgoals.Push(new ArriveGoal(Performer, FS.Position));
            }
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        public override void Terminate()
        {
            /* Leave the FuelStation so other can go to it */
            FS?.Leave();

            /* Terminate the goal as usual */
            base.Terminate();

        }

        /// <summary>
        /// This method will find the NearestRefuelStation
        /// </summary>
        /// <returns></returns>
        private FuelStation? GetNearestFuelStation()
        {
            /* Get all the stations that are rendered */
            List<FuelStation> stations = Performer.world.GetStaticEntityListOf<FuelStation>();

            if (stations.Count != 0)
            {
                FuelStation? NearestFS = null;
                double distanceToNearest = float.PositiveInfinity;

                /* Loop through all the stations */
                foreach (FuelStation station in stations)
                {
                    /* if a station is occupied, skip it. */
                    if (station.IsOccupied()) continue;

                    /* if the distance to the station is closer than the closest one before. Add it to the variables */
                    double nearest = Performer.Position.Distance(station.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestFS = station;
                        distanceToNearest = nearest;
                    }
                }
                return NearestFS;
            }
            return null;
        }
    }
}
