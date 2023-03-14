using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

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

        public override void Interact(MovingEntity CS)
        {
            /* Increasing the Fuel of the CargoShuttle */
            CS.Fuel.Increase(FuelingSpeed);
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - radius), radius * 2, radius * 2);
            g.FillRectangle(Brushes.Purple, r);
            g.DrawString("Fuel", new Font("Arial", 6), Brushes.Black, (int)Position.x - radius - 10, (int)Position.y + radius + 5);
        }
    }
}
