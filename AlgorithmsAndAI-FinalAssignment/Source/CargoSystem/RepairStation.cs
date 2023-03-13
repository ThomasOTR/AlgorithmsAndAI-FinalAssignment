using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
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
            throw new NotImplementedException();
        }
    }
}
