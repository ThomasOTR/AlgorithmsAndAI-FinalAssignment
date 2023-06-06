using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /// <summary>
    /// Class of the station where a CargoShuttle can be refueled.
    /// </summary>
    public class FuelStation : InteractiveLocation
    {
        public double FuelingSpeed = 2;

        public FuelStation(World world, Vector2D position) : base(world, position)
        {
        }

        public FuelStation(World world, Vector2D position, double fuelingSpeed) : base(world, position)
        {
            FuelingSpeed = fuelingSpeed;
        }

        public override void Interact(MovingEntity shuttle)
        {
            /* Triggers the default method which will update the Occuptation state */
            base.Interact(shuttle);

            /* Increasing the Fuel of the CargoShuttle */
            shuttle.Fuel.Increase(FuelingSpeed);
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            /* Draw the Petrolstation Image*/
            g.DrawImage(Resources.FuelStation, r);

            /* Draw the name below the statin for some clarification.*/
            g.DrawString("FuelStation", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);

            base.Render(g);

        }
    }
}
