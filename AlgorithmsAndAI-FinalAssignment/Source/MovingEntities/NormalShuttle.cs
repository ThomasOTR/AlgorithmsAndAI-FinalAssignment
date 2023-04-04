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
            /* Add default Steering that needs to run all the time */
            SteeringBehaviours.Add(new ObstacleAvoidanceBehaviour(this));

            /* Add evaluators to the brain. Otherwise the NormalShuttle will do nothing */
            Brain.AddEvaluators(new List<GoalEvaluator> { new FollowPathEvaluator(), new WanderEvaluator() });
        }
        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - 25), (int)(Position.y - 25), 50, 50);

            /* Calculate the Angle of the Heading of the Entity so i get the nearest 15 degrees. This will choose the specific rendering */
            int RoundedAngle = (int)Math.Round(ConvertHeadingIntoAngle(Heading) / 15);
            object? o = Resources.ResourceManager.GetObject("shuttle_purple_rot" + RoundedAngle) as Image;

            if (!Form1.ForceVisible && o != null) g.DrawImage((Image)o, r);

            /* Trigger the method in the base class. The base class method handles the rendering of the boolean-depending stuff like behaviour */
            base.Render(g);
        }
    }
}
