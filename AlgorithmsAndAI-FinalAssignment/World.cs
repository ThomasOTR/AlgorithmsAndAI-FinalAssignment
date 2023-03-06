using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class World
    {
        public int Width;
        public int Height;

        public List<MovingEntity> Entities;
        public NavigationGraph graph;
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Entities= new List<MovingEntity>();
            graph = new NavigationGraph(this);
            graph.AstarPath(graph.NodeList[1, 1], graph.NodeList[40, 10]);
        }
        public void Update(float delta)
        {
            Entities.ForEach(x => { x.Update(delta); });
        }
        public void Render(Graphics g)
        {
            Entities.ForEach(x => { x.Render(g); });

            if (Form1.GraphVisible)
            {
                graph.Render(g);
            }
        }

        //<summary>
        // A method that will be used to reposition a entity if it is out of the boundaries of the world
        // </summary>
        // <param name = "position" ></param>
        public void WrapAround(Vector2D position)
        {
            if (position.x > Width) position.x = 0.0;

            if (position.x < 0) position.x = Width;

            if (position.y < 0) position.y = Height;

            if (position.y > Height) position.y = 0.0;
        }
    }
}
