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
                Fuel.Decrease(0.15);
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
            //Vector2D WanderDistance = Velocity.Clone();
            //WanderDistance.Normalize();
            //WanderDistance.Multiply(100);
            //WanderDistance.Add(Position);

            //Rectangle b = new Rectangle((int)(WanderDistance.x - 5), (int)(WanderDistance.y - 5), 10, 10);
            //g.DrawRectangle(new Pen(Color.Orange, 1), b);

            //p = new(Color.Red, 1);
            //g.DrawLine(p,
            //    (int)Position.x, (int)Position.y,
            //    (int)WanderDistance.x,
            //    (int)WanderDistance.y
            //    );

        }
    }
}
