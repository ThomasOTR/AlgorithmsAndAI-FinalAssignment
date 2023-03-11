using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    /// <summary>
    /// Class of the station where a CargoShuttle can be refueled.
    /// </summary>
    public class PetrolStation : InteractiveLocation
    {
        public double FuelingSpeed;

        public PetrolStation(World world, Vector2D position, double FuelingSpeed) : base(world, position)
        {
            this.FuelingSpeed = FuelingSpeed;
        }

        public override void Interact(CargoShuttle CS)
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
