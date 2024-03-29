﻿using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

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

        /* Statistic of the Shuttles. This will be decreased over time when travelling. This can be increased at Petrol Stations */
        public Statistic Fuel;

        /* Statistic of the Shuttles. This will be decreased over time when travelling. This can be increased at Repair Stations */
        public Statistic Wear;

        public Cargo? cargo;

        public MovingEntity(World world, Vector2D Position) : base(world, Position)
        {
            Velocity = new Vector2D(0, 0);
            Heading = new Vector2D();
            Side = new Vector2D();
            Mass = 30;
            MaxSpeed = 80;
            Target = null;

            Fuel = new Statistic(100.0);
            Wear = new Statistic(100.0);
            cargo = null;

            Brain = new GoalThink(this);
            SteeringBehaviours = new List<SteeringBehaviour>();

        }

        public override void Update(float delta)
        {
            Brain.Process();

            Vector2D steeringForce = new();
            for (int i = 0; i < SteeringBehaviours.Count; i++)
            {
                steeringForce.Add(SteeringBehaviours[i].Calculate());
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

        /// <summary>
        /// Method to render the Entity
        /// </summary>
        /// <param name="g">Graphics component which can draw what we want.</param>
        public virtual void Render(Graphics g)
        {
            if (Form1.BehaviourVisible) RenderBehavior(g);
            if (Form1.StatsVisibile) RenderStats(g);
            if (Form1.ForceVisible) RenderForce(g);
        }

        /// <summary>
        /// Method to render the Force.
        /// </summary>
        /// <param name="g"></param>
        private void RenderForce(Graphics g)
        {
            Rectangle r = new((int)(Position.x - 15), (int)(Position.y - 15), 30, 30);
            g.DrawRectangle(new Pen(Color.White, 1), r);
            g.DrawLine(new Pen(Color.Red, 1),
                           (int)Position.x, (int)Position.y,
                           (int)(Position.x + (Velocity.x * 25)),
                           (int)(Position.y + (Velocity.y * 25))
                           );
        }

        /// <summary>
        /// A method to render the stats of the Entity
        /// </summary>
        /// <param name="g"></param>
        private void RenderStats(Graphics g)
        {
            string drawString = $"Fuel: {Fuel.currentValue:f2} , Wear: {Wear.currentValue:f2}";

            // Create font and brush.
            g.DrawString(
                s: drawString,
                font: new Font("Arial", 6),
                brush: Brushes.White,
                x: (int)Position.x - 50,
                y: (int)Position.y - 60
                );
        }

        /// <summary>
        /// A method to render the behavior, so every goal the Robot follows.
        /// </summary>
        /// <param name="g"></param>
        private void RenderBehavior(Graphics g)
        {
            g.DrawString(
                s: GetBehaviourOuput(Brain),
                font: SystemFonts.DefaultFont,
                brush: Brushes.White,
                x: (int)Position.x + 30,
                y: (int)Position.y - 20
                );
        }

        /// <summary>
        /// A recursive method to get a string with all the goals in perfect order below each other with spacing.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="amountOfTabs"></param>
        /// <returns></returns>
        private string GetBehaviourOuput(Goal g, int amountOfTabs = 0)
        {
            string output = "";
            /* If the Goal is Composite Goal, go through all the subgoals*/
            if (g is CompositeGoal CG)
            {
                /* Add the name of the CompositeGoal to the output*/
                output += CG.GetName() + "\n";

                /* Loop through all subgoals*/
                foreach (Goal goal in CG.Subgoals)
                {
                    /* Adds tabs in the output so the subgoals will be tabbed*/
                    for (int i = 0; i < amountOfTabs; i++) output += "\t";

                    /* Call the method so we will get the name of a goal tabbed in */
                    output += GetBehaviourOuput(goal, amountOfTabs + 1);

                    /* For each of the goals except the last, add a new line so each goal output will be on a new line.*/
                    if (!CG.Subgoals.Last().Equals(goal)) output += "\n";
                }
                return output;
            }
            /* Return the name if it is a normal goal*/
            else return g.GetName();
        }

        /// <summary>
        /// A method to convert the heading of the entity to an angle */
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float ConvertHeadingIntoAngle(Vector2D v)
        {
            var angle = Math.Atan2(v.y, v.x);
            var degrees = 180 * angle / Math.PI;
            return (float)((360 + Math.Round(degrees)) % 360);
        }
    }
}
