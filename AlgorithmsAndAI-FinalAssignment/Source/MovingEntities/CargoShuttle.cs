using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
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
        public override void Render(Graphics g)
        {
            /* Render the Shuttle*/
            Pen p = new(Color.Black, 1);
            Rectangle r = new Rectangle((int)(Position.x - 20), (int)(Position.y - 20), 20, 20);
            g.DrawRectangle(p, r);

            /* Render the force */
            p = new(Color.Red, 1);
            g.DrawLine(p,
                (int)Position.x, (int)Position.y,
                (int)(Position.x + (Velocity.x * 20)),
                (int)(Position.y + (Velocity.y * 20))
                );

            //int RoundedAngle = (int)Math.Round(calculatedAngle(Heading) / 15);
            //Image i;
            //Object o = Resources.ResourceManager.GetObject("shuttle_rot" + RoundedAngle) as Image;
            //if (o != null) g.DrawImage(o, (int)(Position.x - 20), (int)(Position.y - 20));
            //else
            //{
            //    Pen p = new(Color.Black, 1);
            //    Rectangle r = new Rectangle((int)(Position.x - 20), (int)(Position.y - 20), 20, 20);
            //    g.DrawRectangle(p, r);
            //}


        }
        /// <summary>
        /// Calculates the angle of the Entity's heading
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private float calculatedAngle(Vector2D v)
        {
            var angle = Math.Atan2(v.y, v.x);
            var degrees = 180 * angle / Math.PI;
            return (float)((360 + Math.Round(degrees)) % 360);
        }
    }
}
