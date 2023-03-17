using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class World
    {
        public int Width;
        public int Height;

        public MovingEntity? MainAgent;

        public List<MovingEntity> MovingEntities;
        public List<StaticEntity> StaticEntities;
        public NavigationGraph graph;
        public FuzzyModule BestCargoModule;
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            MovingEntities = new List<MovingEntity>();
            StaticEntities = new List<StaticEntity>();
            MainAgent = null;
            BestCargoModule = WorldBuilder.SetupBestCargoModule(this);

            WorldBuilder.GenerateMovingEntities(this);
            WorldBuilder.GenerateStaticEntities(this);

            graph = new NavigationGraph(this);

        }
        public void Update(float delta)
        {
            if (MainAgent != null) MainAgent.Update(delta);
            StaticEntities.ForEach(x => { x.Update(delta); });
            MovingEntities.ForEach(x => { x.Update(delta); });


        }
        public void Render(Graphics g)
        {
            if (MainAgent != null) MainAgent.Render(g);
            StaticEntities.ForEach(x => { x.Render(g); });
            MovingEntities.ForEach(x => { x.Render(g); });


            if (Form1.GraphVisible)
            {
                graph.Render(g);
            }
        }

        public List<T> GetMovingEntityListOf<T>() where T : MovingEntity
        {
            return MovingEntities.Where(e => e is T).Select(e => (T)e).ToList();
        }
        public List<T> GetStaticEntityListOf<T>() where T : StaticEntity
        {
            return StaticEntities.Where(e => e is T).Select(e => (T)e).ToList();
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
            if (end != null && MainAgent != null)
            {
                Node start = graph.NodeList[Convert.ToInt32(MainAgent.Position.x / size), Convert.ToInt32((MainAgent.Position.y / size))];
                graph.AstarPath(start, end);
            }
        }

        //<summary>
        // A method that will be used to reposition a entity if it is out of the boundaries of the world
        // </summary>
        // <param name = "position" ></param>
        public void WrapAround(Vector2D position)
        {
            if (position.x > Width) position.x = 0.0 + (position.x - Width);

            if (position.x < 0) position.x = Width - Math.Abs(position.x);

            if (position.y < 0) position.y = Height - Math.Abs(position.y);

            if (position.y > Height) position.y = 0.0 + (position.y - Height);
        }
    }
}
