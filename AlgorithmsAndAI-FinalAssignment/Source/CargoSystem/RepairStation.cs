using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    /// <summary>
    /// Class of the Station where a CargoShuttle can be repaired.
    /// </summary>
    public class RepairStation : InteractiveLocation
    {
        public double RepairSpeed;
        public RepairStation(World world, Vector2D position, double RepairSpeed) : base(world, position)
        {
            this.RepairSpeed = RepairSpeed;
        }

        public override void Interact(CargoShuttle CS)
        {
            /* Increase the wear by repairing the shuttle */
            CS.Wear.Increase(RepairSpeed);
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
