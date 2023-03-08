using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.CargoSystem;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    public class CargoShuttle : MovingEntity
    {
        public Cargo? cargo;
        public Statistic Fuel;
        public Statistic Wear;
        public CargoShuttle(World world, Vector2D Position, Vector2D Target) : base(world, Position, Target)
        {
            Fuel = new Statistic(100);
            Wear = new Statistic(100);
        }
        public void AddCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
