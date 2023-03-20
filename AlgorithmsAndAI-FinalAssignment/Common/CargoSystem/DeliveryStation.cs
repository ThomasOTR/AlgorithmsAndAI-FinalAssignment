using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;

namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /// <summary>
    /// Class that of the Delivery station. This is the end location of Cargo.
    /// </summary>
    public class DeliveryStation : InteractiveLocation
    {
        /* The list with the delivered cargo, to keep track how many cargo is delivered. */
        public List<Cargo> DeliveredCargo;

        public DeliveryStation(World world, Vector2D position) : base(world, position)
        {
            DeliveredCargo = new List<Cargo>();
        }

        public override void Interact(MovingEntity CS)
        {
            /* Receive the Cargo and store it. */
            if (CS.cargo != null)
            {
                DeliveredCargo.Add(CS.cargo);
                CS.cargo = null;
            }
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            g.DrawImage(Resources.DeliveryStation, r);

            g.DrawString("DeliveryStation", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);
        }
    }
}
