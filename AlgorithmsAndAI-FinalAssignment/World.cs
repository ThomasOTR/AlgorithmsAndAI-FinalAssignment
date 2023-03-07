using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Entities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class World
    {
        public int Width;
        public int Height;

        public MovingEntity MainAgent;

        public List<MovingEntity> Entities;
        public NavigationGraph graph;
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Entities = new List<MovingEntity>();
            graph = new NavigationGraph(this);

            MainAgent = new PathPlanningAgent(this, new Vector2D(50, 50), null);
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
        public void StartPathFindingProcess(int vectorX, int vectorY)
        {
            double size = NavigationGraph.BetweenNodes;

            Node end = graph.NodeList[Convert.ToInt32(vectorX / size), Convert.ToInt32(vectorY / size)];
            if (end != null)
            {
                Node start = graph.NodeList[Convert.ToInt32(MainAgent.Position.x / size), Convert.ToInt32((MainAgent.Position.y / size))];
                graph.AstarPath(start, end);

                /* Add task to brain */
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
