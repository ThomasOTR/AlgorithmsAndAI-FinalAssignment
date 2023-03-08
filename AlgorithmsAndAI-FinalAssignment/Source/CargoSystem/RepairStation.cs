using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    public class RepairStation : InteractiveLocation
    {
        private double RepairSpeed;
        public RepairStation(World world, Vector2D position, double RepairSpeed) : base(world, position)
        {
            this.RepairSpeed = RepairSpeed;
        }

        public override void Interact(CargoShuttle CS)
        {
            CS.Wear.Increase(RepairSpeed);
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
