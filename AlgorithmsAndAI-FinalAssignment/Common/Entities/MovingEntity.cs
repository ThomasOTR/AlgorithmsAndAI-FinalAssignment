using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity;
        public Vector2D Heading;
        public Vector2D Side;
        public double Mass;
        public double MaxSpeed;
        public BaseGameEntity Target;
        public List<SteeringBehaviour> steeringBehaviours;


        public MovingEntity(World world,Vector2D Position, BaseGameEntity Target) : base(world,Position)
        {
            Velocity = new Vector2D();
            Heading = new Vector2D();
            Side = new Vector2D();
            Mass = 0;
            MaxSpeed = 0;
            this.Target = Target;

            steeringBehaviours = new List<SteeringBehaviour>();

        }
        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Update(float delta)
        {
            Vector2D steeringForce = new Vector2D();
            for (int i = 0; i < steeringBehaviours.Count; i++)
            {
                steeringForce.Add(steeringBehaviours[i].Calculate());
            }

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
    }
}
