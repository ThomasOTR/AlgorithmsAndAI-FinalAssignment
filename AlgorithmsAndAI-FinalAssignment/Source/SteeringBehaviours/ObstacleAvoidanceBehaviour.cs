using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.StaticEntities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class ObstacleAvoidanceBehaviour : SteeringBehaviour
    {
        private double AheadValue = 80;
        private double AvoidingMultiplier = 20;
        public ObstacleAvoidanceBehaviour(MovingEntity ME) : base(ME)
        {
        }
        /// <summary>
        /// Method to find a near obstacle that is in our way.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private SpaceObstacle GetMostThreateningObstacle(Vector2D v1, Vector2D v2)
        {
            SpaceObstacle threat = null;

            /* Loop through all space obstacles */

            foreach (SpaceObstacle SO in ME.world.GetStaticEntityListOf<SpaceObstacle>())
            {
                /* Calculate the distance from the detection points to an obstacle */
                double distance1 = SO.Position.Distance(v1);
                double distance2 = SO.Position.Distance(v2);

                /* 
                 * Check if the distance from the feelers to the position of the obstacle is within the radius of the obstacle
                 * This is important because if the distance is smaller than the radius, the MovingEntity needs to avoid.
                 */
                if (SO.radius > distance1 || SO.radius > distance2) continue;
                else
                {
                    /* Set this obstacle as threat if:
                     *   - Threat is null
                     *   - Distance from MovingEntity to this obstacle is smaller than the distance to current Threat
                     */
                    if (threat == null || ME.Position.Distance(SO.Position) < ME.Position.Distance(threat.Position))
                        threat = SO;
                }
            }
            return threat;
        }

        public override Vector2D Calculate()
        {
            /* Create a feeler ahead like the WanderPoint in the WanderBehaviour*/
            Vector2D FrontFeelerPosition = ME.Velocity.Clone();
            if (FrontFeelerPosition.Equals(new Vector2D())) FrontFeelerPosition = new Vector2D(0.1, 0.1);

            FrontFeelerPosition.Normalize();
            FrontFeelerPosition.Multiply(AheadValue);
            FrontFeelerPosition.Add(ME.Position);

            /* Create a feeler between FrontFeeler and MovingEntity */
            Vector2D MidFeelerPosition = FrontFeelerPosition.Clone().Multiply(0.5);

            /* Get a threat*/
            SpaceObstacle Threat = GetMostThreateningObstacle(FrontFeelerPosition, MidFeelerPosition);

            /* if there is no threat, move to the Feeler position which is straight ahead */
            if (Threat == null) return FrontFeelerPosition;

            /* If there is a threat, calculate the avoiding force so the moving entity will not bump into an obstacle */
            else
            {
                /* Avoiding position is Feeler minus the threat position. This is done this way so the entity moves enough to not bump into the obstacle */
                Vector2D AvoidingForce = FrontFeelerPosition.Subtract(Threat.Position);
                AvoidingForce.Normalize().Multiply(AvoidingMultiplier);
                return AvoidingForce;
            }
        }
    }
}
