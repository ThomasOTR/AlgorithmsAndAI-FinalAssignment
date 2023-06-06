using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;

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

        public RepairStation(World world, Vector2D position, double repairSpeed) : base(world, position)
        {
            RepairSpeed = repairSpeed;
        }

        public override void Interact(MovingEntity shuttle)
        {
            /* Triggers the default method which will update the Occuptation state */
            base.Interact(shuttle);

            /* Increase the wear by repairing the shuttle */
            shuttle.Wear.Increase(RepairSpeed);
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            /* Draw the Repairstation image */
            g.DrawImage(Resources.RepairStation, r);

            /* Draw the name below the statin for some clarification.*/
            g.DrawString("RepairStation", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);

            base.Render(g);


        }
    }
}
