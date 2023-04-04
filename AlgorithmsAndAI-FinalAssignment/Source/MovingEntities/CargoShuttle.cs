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

            /* Run the base Update method which will calculate steering and updates the brain */
            base.Update(deltaTime);

        }
        public override void Render(Graphics g)
        {
            /* A rectangle with the position in the middle*/
            Rectangle r = new((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);

            /* Calculate the angle of the heading and divide it by 15 to get the best image based on the angle  */
            int RoundedAngle = (int)Math.Round(ConvertHeadingIntoAngle(Heading) / 15);
            object? o = Resources.ResourceManager.GetObject("shuttle_blue_rot" + RoundedAngle) as Image;

            if (!Form1.ForceVisible && o != null) g.DrawImage((Image)o, r);


            /* Trigger the method in the base class. The base class method handles the rendering of the boolean-depending stuff like behaviour */
            base.Render(g);

        }
    }
}
