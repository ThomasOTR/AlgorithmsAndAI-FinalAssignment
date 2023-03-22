using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using Timer = System.Timers.Timer;

namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will collect the best cargo suited to the shuttle
    /// </summary>
    public class GetCargoGoal : Goal
    {
        private CargoWarehouse CW;
        private Timer timer;

        public GetCargoGoal(MovingEntity movingEntity, CargoWarehouse CW) : base(movingEntity)
        {
            this.CW = CW;
            timer = new Timer() { Interval = 3000 };
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Status = GoalStatus.Completed;
        }

        public override void Activate()
        {
            base.Activate();
            timer.Start();
        }


        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* The interaction between the Warehouse and the shuttle. This time the interaction is loading a cargo into the shuttle */
            CW.Interact(Performer);

            return Status;

        }
    }
}
