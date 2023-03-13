using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
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
            throw new NotImplementedException();
        }
    }
}
