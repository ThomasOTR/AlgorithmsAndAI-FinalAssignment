using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Steering;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Steering
{
    public class LeaderFollowingBehaviour : SteeringBehaviour
    {
        public LeaderFollowingBehaviour(MovingEntity ME) : base(ME)
        {
        }

        public override Vector2D Calculate()
        {
            return new Vector2D();
        }
    }
}
