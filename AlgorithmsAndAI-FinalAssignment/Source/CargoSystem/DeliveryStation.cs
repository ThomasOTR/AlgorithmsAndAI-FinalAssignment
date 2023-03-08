using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    public class DeliveryStation : InteractiveLocation
    {
        public List<Cargo> DeliveredCargo;

        public DeliveryStation(World world, Vector2D position) : base(world, position)
        {
            DeliveredCargo = new List<Cargo>();
        }

        public override void Interact(CargoShuttle CS)
        {
            if (CS.cargo != null)
            {
                DeliveredCargo.Add(CS.cargo);
                CS.cargo = null;
            }
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
