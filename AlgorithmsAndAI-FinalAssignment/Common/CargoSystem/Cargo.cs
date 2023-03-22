namespace AlgorithmsAndAI_FinalAssignment.Common.CargoSystem
{
    /// <summary>
    /// Part of the Simulation. This cargo will be delivered from Warehouse to DeliveryStation.
    /// </summary>
    public class Cargo
    {
        /* The name of the cargo, which will be used to identify this cargo */
        public string Name;

        /* The target of this cargo. Which will be used in the delivery process */
        public DeliveryStation TargetLocation;

        public static string[] CargoNames = { "Weapons", "Droids", "Technological Innovations", "Food" };

        public Cargo(string Name, DeliveryStation targetLocation)
        {
            this.Name = Name;
            TargetLocation = targetLocation;
        }

    }
}
