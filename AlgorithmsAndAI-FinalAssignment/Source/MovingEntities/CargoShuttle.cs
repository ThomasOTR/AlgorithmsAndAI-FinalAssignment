using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// The main entity that will be perform goals by steering and logic.
    /// </summary>
    public class CargoShuttle : MovingEntity
    {
        /* Cargo of this shuttle. This will be filled at a CargoWarehouse and will be emptied by a DeliveryStation. */
        public Cargo? cargo;

        /* Statistic of the Shuttle. This will be decreased over time when travelling. This can be increased at Petrol Stations */
        public Statistic Fuel;

        /* Statistic of the SHuttle. This will be decreased over time when travelling. This can be increased at Repair Stations */
        public Statistic Wear;

        int bla = 0;

        public CargoShuttle(World world, Vector2D Position) : base(world, Position)
        {
            Fuel = new Statistic(100.0);
            Wear = new Statistic(100.0);
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
            Fuel.Decrease(0.15);
            Wear.Decrease(0.1);

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
