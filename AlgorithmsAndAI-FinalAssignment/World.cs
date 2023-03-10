using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.MovingEntities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class World
    {
        public int Width;
        public int Height;

        public MovingEntity MainAgent;

        public List<MovingEntity> MovingEntities;
        public List<StaticEntity> StaticEntities;
        public NavigationGraph graph;
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            MovingEntities = new List<MovingEntity>();
            StaticEntities = new List<StaticEntity>();
            MainAgent = new NormalShuttle(this, new Vector2D(50, 50));

            WorldBuilder.GenerateMovingEntities(this);
            WorldBuilder.GenerateStaticEntities(this);

            graph = new NavigationGraph(this);

        }
        public void Update(float delta)
        {
            MovingEntities.ForEach(x => { x.Update(delta); });
            StaticEntities.ForEach(x => { x.Update(delta); });

        }
        public void Render(Graphics g)
        {
            MovingEntities.ForEach(x => { x.Render(g); });
            StaticEntities.ForEach(x => { x.Render(g); });

            if (Form1.GraphVisible)
            {
                graph.Render(g);
            }
        }
        /// <summary>
        /// Method to start Path finding Process
        /// </summary>
        /// <param name="vectorX"></param>
        /// <param name="vectorY"></param>
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
