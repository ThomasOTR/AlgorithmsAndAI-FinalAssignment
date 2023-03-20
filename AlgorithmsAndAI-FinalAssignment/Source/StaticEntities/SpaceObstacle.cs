using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Source.StaticEntities
{
    public class SpaceObstacle : StaticEntity
    {
        private Image ImageToRender;
        public SpaceObstacle(World world, Vector2D position, Bitmap image, int radius) : base(world, position)
        {
            ImageToRender = image;
            this.radius = radius;
        }

        public override void Render(Graphics g)
        {
            Rectangle r = new((int)(Position.x - radius), (int)(Position.y - radius), radius * 2, radius * 2);
            g.DrawImage(ImageToRender, r);
        }
    }
}
