using AlgorithmsAndAI_FinalAssignment.Properties;
using Timer = System.Timers.Timer;
namespace AlgorithmsAndAI_FinalAssignment
{
    public partial class Form1 : Form
    {
        private World world;
        private Timer timer;
        private float timeDelta = 0.8f;

        /* A bool to show the Graph */
        public static bool GraphVisible = false;

        /* A bool to show the Force of each Shuttle */
        public static bool ForceVisible = false;

        /* A bool to show the stats of each shuttle */
        public static bool StatsVisibile = false;

        /* A bool to show the current behaviour of each shuttle */
        public static bool BehaviourVisible = false;

        /* A bool to enable a simplified look.*/
        public static bool SimplifiedMovingEntityLook = false;

        /* A bool to show details of each Location */
        public static bool LocationDetails = false;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            world = new World(width: Width, height: Height);
            Paint += Form1_Paint;
            timer = new Timer()

            {
                Interval = 40,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;
            BackgroundImage = Resources.bg1;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
            Invalidate();
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            world.Render(e.Graphics);
        }
        private void InputHandler(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    BehaviourVisible = !BehaviourVisible; break;
                case Keys.D:
                    LocationDetails = !LocationDetails; break;
                case Keys.F:
                    ForceVisible = !ForceVisible; break;
                case Keys.G:
                    GraphVisible = !GraphVisible; break;
                case Keys.L:
                    SimplifiedMovingEntityLook = !SimplifiedMovingEntityLook; break;
                case Keys.S:
                    StatsVisibile = !StatsVisibile; break;

                case Keys.Escape:
                    Application.Exit(); break;
            }
        }
        private void OnClick(object sender, MouseEventArgs e)
        {
            world.StartPathPlanning(e.X, e.Y);

        }

    }
}