using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using Timer = System.Timers.Timer;


namespace AlgorithmsAndAI_FinalAssignment.Source.Goals.AtomicGoals
{
    /// <summary>
    /// This goal will drop off the cargo from the shuttle to the Delivery station.
    /// </summary>
    public class DropOffCargoGoal : Goal
    {
        /* The destination of the Cargo */
        private DeliveryStation station;

        private Timer timer;


        public DropOffCargoGoal(MovingEntity movingEntity, DeliveryStation station) : base(movingEntity)
        {
            this.station = station;
            timer = new Timer() { Interval = 5000 };
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
        }

        /// <summary>
        /// A method to set the Status to Complete. Because of the settings of the Timer, it will only trigger once.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Status = GoalStatus.Completed;
        }

        /// <summary>
        /// Trigger the Activate of the base class and starts the timer.
        /// </summary>
        public override void Activate()
        {
            base.Activate();
            timer.Start();
        }

        public override GoalStatus Process()
        {
            if (Status == GoalStatus.Inactive) Activate();

            /* With this line the Performer will interact with the station. In this case interact is moving the cargo from shuttle to station */
            station.Interact(Performer);

            return Status;
        }
    }
}
