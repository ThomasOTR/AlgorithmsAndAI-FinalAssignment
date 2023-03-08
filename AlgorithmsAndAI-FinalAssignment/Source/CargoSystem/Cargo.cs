namespace AlgorithmsAndAI_FinalAssignment.Source.CargoSystem
{
    public class Cargo
    {
        public string Name;
        public DeliveryStation TargetLocation;

        public Cargo(string Name, DeliveryStation targetLocation)
        {
            this.Name = Name;
            TargetLocation = targetLocation;
        }

    }
}
