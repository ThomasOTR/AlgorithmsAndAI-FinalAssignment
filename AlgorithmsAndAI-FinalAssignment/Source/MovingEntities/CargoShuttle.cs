using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// The main entity that will be perform goals by steering and logic.
    /// </summary>
    public class CargoShuttle : MovingEntity
    {
        public CargoShuttle(World world, Vector2D Position) : base(world, Position)
        {
            SteeringBehaviours.Add(new ObstacleAvoidanceBehaviour(this));
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
            Rectangle r = new Rectangle((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);

            int RoundedAngle = (int)Math.Round(calculatedAngle(Heading) / 15);
            object o = Resources.ResourceManager.GetObject("shuttle_blue_rot" + RoundedAngle) as Image;

            if (o == null || Form1.SimplifiedLook) RenderSimplified(g, Color.White);
            else g.DrawImage((Image)o, r);

            g.DrawString(
                s: "Bla" + SteeringBehaviours.Count(),
                font: new Font("Arial", 6),
                brush: Brushes.White,
                x: (int)Position.x - 50,
                y: (int)Position.y - 60
                );

            base.Render(g);

            //Vector2D bla = Velocity.Clone();
            //if (bla.Equals(new Vector2D())) bla = new Vector2D(0.1, 0.1);

            //Vector2D FrontFeelerPosition = bla.Clone().Normalize();
            //FrontFeelerPosition.Multiply(80);
            //FrontFeelerPosition.Add(Position);


            //g.DrawLine(new Pen(Color.Yellow, 1), (int)Position.x, (int)Position.y, (int)FrontFeelerPosition.x, (int)FrontFeelerPosition.y);

            ///* Create a feeler between FrontFeeler and MovingEntity */
            //Vector2D MidFeelerPosition = bla.Clone().Normalize();
            //MidFeelerPosition.Multiply(40);
            //MidFeelerPosition.Add(Position);
            //g.DrawLine(new Pen(Color.Yellow, 1), (int)Position.x, (int)Position.y, (int)MidFeelerPosition.x, (int)MidFeelerPosition.y);
        }
    }
}
