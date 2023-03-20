using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// The main entity that will be perform goals by steering and logic.
    /// </summary>
    public class CargoShuttle : MovingEntity
    {
        public CargoShuttle(World world, Vector2D Position) : base(world, Position)
        {
            Brain.AddEvaluators(new List<GoalEvaluator>
            {
                new WanderEvaluator(),
                new DeliverCargoEvaluator(),
                new GoRefuelEvaluator(),
                new GoRepairEvaluator(),
                new ReceiveNewCargoEvaluator(),
            }
            );
        }

        /// <summary>
        /// Method to load the ship with cargo.
        /// </summary>
        /// <param name="cargo"></param>
        public void AddCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }
        public override void Update(float deltaTime)
        {
            /* This will prevent fuel and wear decrease while standing still. */
            if (Velocity.Length() > 0)
            {
                Fuel.Decrease(0.05);
                Wear.Decrease(0.1);
            }
            base.Update(deltaTime);

        }
        private void RenderSimplified(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);
            g.DrawRectangle(new Pen(Color.Black, 1), r);

            g.DrawLine(new Pen(Color.Red, 1),
                (int)Position.x, (int)Position.y,
                (int)(Position.x + (Velocity.x * 25)),
                (int)(Position.y + (Velocity.y * 25))
                );
        }
        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);

            int RoundedAngle = (int)Math.Round(calculatedAngle(Heading) / 15);
            object o = Resources.ResourceManager.GetObject("shuttle_blue_rot" + RoundedAngle) as Image;

            if (o == null || Form1.SimplifiedLook) RenderSimplified(g);
            else g.DrawImage((Image)o, r);

            base.Render(g);

        }
        /// <summary>
        /// Calculates the angle of the Entity's heading
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static float calculatedAngle(Vector2D v)
        {
            var angle = Math.Atan2(v.y, v.x);
            var degrees = 180 * angle / Math.PI;
            return (float)((360 + Math.Round(degrees)) % 360);
        }
    }
}
