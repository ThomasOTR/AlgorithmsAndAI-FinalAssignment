using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /// <summary>
    /// Class of the Station where a CargoShuttle can be repaired.
    /// </summary>
    public class RepairStation : InteractiveLocation
    {
        public double RepairSpeed = 2;
        public RepairStation(World world, Vector2D position) : base(world, position)
        {
        }

        public override void Interact(MovingEntity CS)
        {
            /* Increase the wear by repairing the shuttle */
            CS.Wear.Increase(RepairSpeed);
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - radius), radius * 2, radius * 2);
            g.FillRectangle(Brushes.Red, r);
            g.DrawString("Repair", new Font("Arial", 6), Brushes.Black, (int)Position.x - radius - 10, (int)Position.y + radius + 5);
        }
    }
}
