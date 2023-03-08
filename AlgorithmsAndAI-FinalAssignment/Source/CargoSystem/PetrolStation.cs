using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    public class PetrolStation : InteractiveLocation
    {
        private double FuelingSpeed;

        public PetrolStation(World world, Vector2D position, double FuelingSpeed) : base(world, position)
        {
            this.FuelingSpeed = FuelingSpeed;
        }

        public override void Interact(CargoShuttle CS)
        {
            CS.Fuel.Increase(FuelingSpeed);
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
