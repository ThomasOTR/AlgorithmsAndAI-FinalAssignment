using Timer = System.Timers.Timer;
namespace AlgorithmsAndAI_FinalAssignment
{
    
    public partial class Form1 : Form
    {
        private World world;
        private Timer timer;
        private float timeDelta = 0.8f;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered= true;

            world = new World(width:Width, height:Height);
            Paint += Form1_Paint;
            timer = new Timer()
            {
                Interval = 20,
                Enabled = true,
            };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            world.Render(e.Graphics);
        }
    }
}