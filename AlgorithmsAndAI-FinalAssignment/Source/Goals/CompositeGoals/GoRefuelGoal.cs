using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    /// <summary>
    /// This goal will move the shuttle to a PetrolStation and refuel the shuttle
    /// </summary>
    public class GoRefuelGoal : CompositeGoal
    {
        public GoRefuelGoal(MovingEntity ME) : base(ME)
        {
        }
        public override void Activate()
        {
            base.Activate();

            PetrolStation PS = GetNearestRefuelStation();

            Subgoals.Push(new RefuelGoal(Performer, PS));
            Subgoals.Push(new ArriveGoal(Performer, PS.Position));
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }
        /// <summary>
        /// This method will find the NearestRefuelStation
        /// </summary>
        /// <returns></returns>
        private PetrolStation GetNearestRefuelStation()
        {
            List<PetrolStation> stations = Performer.world.GetStaticEntityListOf<PetrolStation>();

            if (stations.Count == 0)
            {
                PetrolStation PS = new PetrolStation(Performer.world, new Vector2D(500, 100));
                Performer.world.StaticEntities.Add(PS);
                return PS;
            }
            else
            {
                PetrolStation NearestPS = new PetrolStation(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;
                foreach (PetrolStation station in stations)
                {
                    double nearest = Performer.Position.Distance(station.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestPS = station;
                        distanceToNearest = nearest;
                    }
                }
                return NearestPS;
            }
        }
    }
}
