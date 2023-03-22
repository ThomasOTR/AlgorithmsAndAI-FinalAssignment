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
            base.Activate();

            RS = GetNearestRepairStation();
            if (RS != null)
            {
                RS.Claim(Performer);

                Subgoals.Push(new RepairGoal(Performer, RS));
                Subgoals.Push(new ArriveGoal(Performer, RS.Position));
            }
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
            List<RepairStation> stations = Performer.world.GetStaticEntityListOf<RepairStation>();

            if (stations.Count != 0)
            {
                RepairStation NearestRS = new(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;
                foreach (RepairStation station in stations)
                {
                    if (station.IsOccupied()) continue;
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
            RS?.Leave();

            base.Terminate();

        }
    }
}
