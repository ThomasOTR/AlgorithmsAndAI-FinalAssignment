using AlgorithmsAndAI_FinalAssignment.Properties;
using Timer = System.Timers.Timer;
namespace AlgorithmsAndAI_FinalAssignment
{
    public partial class Form1 : Form
    {
        private readonly World world;
        private readonly Timer timer;
        private readonly float timeDelta = 0.8f;

        /* A bool to show the Graph */
        public static bool GraphVisible = false;

        /* A bool to show the Force of each Shuttle with a simplified look to see it better. */
        public static bool ForceVisible = false;

        /* A bool to show the stats of each shuttle */
        public static bool StatsVisibile = false;

        /* A bool to show the current behaviour of each shuttle */
        public static bool BehaviourVisible = false;

        /* A bool to show details of each Location */
        public static bool LocationDetails = false;

        public Form1()
        {
            InitializeComponent();

            world = new World(width: WorldCanvas.Width, height: WorldCanvas.Height);
            WorldCanvas.Paint += PaintEvent;

            timer = new Timer()

            {
                Interval = 40,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;

            WorldCanvas.BackgroundImage = Resources.bg1;
        }

        /// <summary>
        /// This updates the world class and helps the redraw of the canvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
            WorldCanvas.Invalidate();
        }

        /// <summary>
        /// This 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintEvent(object? sender, PaintEventArgs e)
        {
            world.Render(e.Graphics);
        }
        /// <summary>
        /// The onclick event when 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, MouseEventArgs e)
        {
            world.StartPathPlanning(e.X, e.Y);
        }

        /// <summary>
        /// This method updates the boolean to the corresponding checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Outputs_CheckedChanged(object sender, EventArgs e)
        {
            BehaviourVisible = checkBoxBehaviour.Checked;
            LocationDetails = checkBoxLocationDetails.Checked;
            ForceVisible = checkBoxForce.Checked;
            GraphVisible = checkBoxGraph.Checked;
            StatsVisibile = checkBoxStats.Checked;
        }

    }
}