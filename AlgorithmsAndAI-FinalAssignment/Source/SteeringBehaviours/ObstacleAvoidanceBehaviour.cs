using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.StaticEntities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class ObstacleAvoidanceBehaviour : SteeringBehaviour
    {
        private double AheadValue = 60;
        private double AvoidingMultiplier = 40;
        public ObstacleAvoidanceBehaviour(MovingEntity ME) : base(ME)
        {
        }
        /// <summary>
        /// Method to find a near obstacle that is in our way.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private SpaceObstacle? GetMostThreateningObstacle(Vector2D v1)
        {
            SpaceObstacle? threat = null;

            /* Loop through all space obstacles */
            foreach (SpaceObstacle SO in ME.world.GetStaticEntityListOf<SpaceObstacle>())
            {
                /* Calculate the distance from the detection point to an obstacle */
                double distance = SO.Position.Distance(v1);

                /* 
                 * Check if the distance from the feelers to the position of the obstacle is within the radius of the obstacle
                 * This is important because if the distance is smaller than the radius, the MovingEntity needs to avoid.
                 */
                if ((SO.radius * 2) <= distance) continue;
                else
                {
                    /* Set this obstacle as threat if:
                     *   - Threat is null
                     *   - Distance from MovingEntity to this obstacle is smaller than the distance to current Threat
                     */
                    if (threat == null || ME.Position.Distance(SO.Position) < ME.Position.Distance(threat.Position))
                    {
                        threat = SO;
                    }
                }
            }
            return threat;
        }

        public override Vector2D Calculate()
        {
            /* Create a feeler ahead like the WanderPoint in the WanderBehaviour*/

            Vector2D StartingVelocity = ME.Velocity.Clone();
            if (StartingVelocity.Equals(new Vector2D())) StartingVelocity = new Vector2D(0.1, 0.1);

            Vector2D FrontFeelerPosition = StartingVelocity.Clone().Normalize();
            FrontFeelerPosition.Multiply(AheadValue);
            FrontFeelerPosition.Add(ME.Position);

            /* Get a threat*/
            SpaceObstacle? Threat = GetMostThreateningObstacle(FrontFeelerPosition);

            /* if there is no threat, move to the Feeler position which is straight ahead */
            if (Threat == null) return ME.Velocity;

            /* If there is a threat, calculate the avoiding force so the moving entity will not bump into an obstacle */
            else
            {
                /* Avoiding position is Feeler minus the threat position. This is done this way so the entity moves enough to not bump into the obstacle */
                Vector2D AvoidingForce = FrontFeelerPosition.Clone().Subtract(Threat.Position);
                AvoidingForce.Normalize().Multiply(AvoidingMultiplier);
                return AvoidingForce;
            }
        }
    }
}
