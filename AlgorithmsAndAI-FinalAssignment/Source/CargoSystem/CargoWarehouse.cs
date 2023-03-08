using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    public class CargoWarehouse : InteractiveLocation
    {
        public List<Cargo> CargoForDelivery;
        public CargoWarehouse(World world, Vector2D position) : base(world, position)
        {
            CargoForDelivery = new List<Cargo>();
        }

        public override void Interact(CargoShuttle shuttle)
        {
            if (shuttle.cargo != null) return;

            shuttle.AddCargo(CargoForDelivery.First());
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
