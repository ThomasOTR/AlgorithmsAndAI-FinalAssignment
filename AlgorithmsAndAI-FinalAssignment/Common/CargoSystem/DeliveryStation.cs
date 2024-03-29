﻿using AlgorithmsAndAI_FinalAssignment.Common.Entities;
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

        public override void Interact(MovingEntity shuttle)
        {
            /* Triggers the default method which will update the Occuptation state */
            base.Interact(shuttle);

            /* Receive the Cargo and store it. */
            if (shuttle.cargo != null)
            {
                DeliveredCargo.Add(shuttle.cargo);
                shuttle.cargo = null;
            }
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - radius), (int)(Position.y - (radius * 0.5)), radius * 2, radius);

            /* Draw the DeliveryStation Image*/
            g.DrawImage(Resources.DeliveryStation, r);

            /* Draw the name below the station for some clarification.*/
            g.DrawString("DeliveryStation", new Font("Arial", 6), Brushes.White, (int)Position.x - radius + 10, (int)Position.y + 20);

            base.Render(g);

        }
    }
}
