using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    /// <summary>
    /// This goal will move the shuttle to the nearest repairstation and repair the shuttle
    /// </summary>
    public class GoRepairGoal : CompositeGoal
    {
        private RepairStation? RS;
        public GoRepairGoal(MovingEntity ME) : base(ME)
        {
            RS = null;
        }
        public override void Activate()
        {
            /* Activate the goal*/
            base.Activate();

            /* Get the nearest available refuel station */
            RS = GetNearestRepairStation();

            /* if there is one RepairStation available, claim it and add the goals in opposite order*/
            if (RS != null)
            {
                RS.Claim(Performer);

                Subgoals.Push(new RepairGoal(Performer, RS));
                Subgoals.Push(new ArriveGoal(Performer, RS.Position));
            }

            /* If there is no petrol station to go, this goal is failed*/
            else Status = GoalStatus.Failed;
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        /// <summary>
        /// This method will find the nearest RepairStation
        /// </summary>
        /// <returns></returns>
        private RepairStation? GetNearestRepairStation()
        {
            /* Get all the stations that are rendered */
            List<RepairStation> stations = Performer.world.GetStaticEntityListOf<RepairStation>();

            if (stations.Count != 0)
            {
                RepairStation NearestRS = new(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;

                /* Loop through all the stations */
                foreach (RepairStation station in stations)
                {
                    /* if a station is occupied, skip it. */
                    if (station.IsOccupied()) continue;

                    /* if the distance to the station is closer than the closest one before. Add it to the variables */
                    double nearest = Performer.Position.Distance(station.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestRS = station;
                        distanceToNearest = nearest;
                    }
                }
                return NearestRS;
            }
            return null;
        }

        public override void Terminate()
        {
            /* Leave the RepairStation so other can go to it */
            RS?.Leave();

            /* Terminate the goal as usual */
            base.Terminate();

        }
    }
}
