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
        public GoRepairGoal(MovingEntity ME) : base(ME)
        {
        }
        public override void Activate()
        {
            base.Activate();

            RepairStation RS = GetNearestRepairStation();

            Subgoals.Push(new RepairGoal(Performer, RS));
            Subgoals.Push(new ArriveGoal(Performer, RS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        /// <summary>
        /// This method will find the nearest RepairStation
        /// </summary>
        /// <returns></returns>
        private RepairStation GetNearestRepairStation()
        {
            List<RepairStation> stations = Performer.world.GetStaticEntityListOf<RepairStation>();

            if (stations.Count == 0)
            {
                RepairStation RS = new(Performer.world, new Vector2D(500, 100));
                Performer.world.StaticEntities.Add(RS);
                return RS;
            }
            else
            {
                RepairStation NearestRS = new(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;
                foreach (RepairStation station in stations)
                {
                    double nearest = Performer.Position.Distance(station.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestRS = station;
                        distanceToNearest = nearest;
                    }
                }
                return NearestRS;
            }
        }
    }
}
