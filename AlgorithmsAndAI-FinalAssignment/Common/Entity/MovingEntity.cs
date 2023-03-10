using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System.Diagnostics;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class MovingEntity : BaseGameEntity
    {
        /* The speed in a given direction */
        public Vector2D Velocity;

        /* Vector normalized pointing in the direction the entity will head */
        public Vector2D Heading;

        /* Perped Heading */
        public Vector2D Side;

        /* Mass of the Entity, which will have impact on the speed */
        public double Mass;

        /* Maximum Speed of entity, which will be used to check if Entity is going too fast */
        public double MaxSpeed;

        /* Target Property which will be used for the Steering Behaviour */
        public Vector2D? Target;

        /* All the SteeringBehaviours that are enabled and will be calculated */
        public List<SteeringBehaviour> SteeringBehaviours;

        /* Brain of the Entity. The brain will decide */
        public GoalThink Brain;


        public MovingEntity(World world, Vector2D Position) : base(world, Position)
        {
            Velocity = new Vector2D();
            Heading = new Vector2D();
            Side = new Vector2D();
            Mass = 50;
            MaxSpeed = 50;
            Target = null;

            Brain = new GoalThink(this);
            SteeringBehaviours = new List<SteeringBehaviour>();

        }

        public override void Update(float delta)
        {
            Debug.WriteLine(Velocity.ToString());

            Vector2D steeringForce = new();
            for (int i = 0; i < SteeringBehaviours.Count; i++)
            {
                Vector2D tempForce = SteeringBehaviours[i].Calculate();
                //steeringForce.Add(SteeringBehaviours[i].Calculate());
                steeringForce.Add(tempForce);
            }
            Debug.WriteLine(steeringForce.ToString());
            Vector2D acceleration = steeringForce.Divide(Mass);

            Velocity.Add(acceleration.Multiply(delta));
            Velocity.Truncate(MaxSpeed);
            Position.Add(Velocity.Multiply(delta));

            if (Velocity.Length() > 0.00000001)
            {
                Heading = Velocity.Normalize();

                Side = Heading.Perp();
            }

            world.WrapAround(Position);

        }


        /// <summary>
        /// Method to render the Entity
        /// </summary>
        /// <param name="g">Graphics component which can draw what we want.</param>
        public abstract void Render(Graphics g);
    }
}
