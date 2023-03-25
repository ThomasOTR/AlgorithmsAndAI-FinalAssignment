using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /// <summary>
    /// Class of the station where a CargoShuttle can be refueled.
    /// </summary>
    public class PetrolStation : InteractiveLocation
    {
        public double FuelingSpeed = 2;

        public PetrolStation(World world, Vector2D position) : base(world, position)
        {
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
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            g.DrawImage(Resources.PetrolStation, r);

            g.DrawString("FuelStation", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);

            base.Render(g);

        }
    }
}
