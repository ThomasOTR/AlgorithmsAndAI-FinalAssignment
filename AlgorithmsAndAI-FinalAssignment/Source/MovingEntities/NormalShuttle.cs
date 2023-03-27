using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goals;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Properties;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators;
using AlgorithmsAndAI_FinalAssignment.Steering;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// A normal shuttle that will follow the shortest path;
    /// </summary>
    public class NormalShuttle : MovingEntity
    {
        public NormalShuttle(World world, Vector2D position) : base(world, position)
        {
            SteeringBehaviours.Add(new ObstacleAvoidanceBehaviour(this));
            Brain.AddEvaluators(new List<GoalEvaluator> { new FollowPathEvaluator(), new WanderEvaluator() });
        }
        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);

            int RoundedAngle = (int)Math.Round(ConvertHeadingIntoAngle(Heading) / 15);
            object? o = Resources.ResourceManager.GetObject("shuttle_purple_rot" + RoundedAngle) as Image;

            if (o == null || Form1.SimplifiedMovingEntityLook) RenderSimplified(g, Color.LightBlue);
            else g.DrawImage((Image)o, r);

            base.Render(g);
        }
    }
}
