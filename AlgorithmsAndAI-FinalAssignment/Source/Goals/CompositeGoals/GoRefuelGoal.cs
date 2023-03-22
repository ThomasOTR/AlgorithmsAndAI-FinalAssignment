using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.CompositeGoals
{
    /// <summary>
    /// This goal will move the shuttle to a PetrolStation and refuel the shuttle
    /// </summary>
    public class GoRefuelGoal : CompositeGoal
    {
        private PetrolStation? PS;
        public GoRefuelGoal(MovingEntity ME) : base(ME)
        {
            PS = null;
        }
        public override void Activate()
        {
            base.Activate();

            PS = GetNearestRefuelStation();
            if (PS == null) Status = GoalStatus.Failed;
            else
            {
                PS.Claim(Performer);

                Subgoals.Push(new RefuelGoal(Performer, PS));
                Subgoals.Push(new ArriveGoal(Performer, PS.Position));
            }
        }
        public override GoalStatus Process()
        {
            return ProcessSubgoals();
        }

        public override void Terminate()
        {
            PS?.Leave();

            base.Terminate();


        }

        /// <summary>
        /// This method will find the NearestRefuelStation
        /// </summary>
        /// <returns></returns>
        private PetrolStation? GetNearestRefuelStation()
        {
            List<PetrolStation> stations = Performer.world.GetStaticEntityListOf<PetrolStation>();

            if (stations.Count != 0)
            {
                PetrolStation NearestPS = new PetrolStation(Performer.world, new Vector2D());
                double distanceToNearest = float.PositiveInfinity;
                foreach (PetrolStation station in stations)
                {
                    if (station.IsOccupied()) continue;
                    double nearest = Performer.Position.Distance(station.Position);
                    if (nearest < distanceToNearest)
                    {
                        NearestPS = station;
                        distanceToNearest = nearest;
                    }
                }
                return NearestPS;
            }
            return null;
        }
    }
}
