using AlgorithmsAndAI_FinalAssignment.Properties;
using Timer = System.Timers.Timer;
namespace AlgorithmsAndAI_FinalAssignment
{
    public partial class Form1 : Form
    {
        private World world;
        private Timer timer;
        private float timeDelta = 0.8f;

        public static bool GraphVisible = false;
        public static bool StatsVisibile = false;
        public static bool BehaviourVisible = false;
        public static bool SimplifiedMovingEntityLook = false;
        public static bool StaticEntityDetails = false;

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
                case Keys.G:
                    GraphVisible = !GraphVisible; break;
                case Keys.S:
                    StatsVisibile = !StatsVisibile; break;
                case Keys.B:
                    BehaviourVisible = !BehaviourVisible; break;
                case Keys.L:
                    SimplifiedMovingEntityLook = !SimplifiedMovingEntityLook; break;
                case Keys.D:
                    StaticEntityDetails = !StaticEntityDetails; break;
                case Keys.Escape:
                    Application.Exit(); break;
            }
        }
        private void OnClick(object sender, MouseEventArgs e)
        {
            world.StartPathFindingProcess(e.X, e.Y);

        }

    }
}