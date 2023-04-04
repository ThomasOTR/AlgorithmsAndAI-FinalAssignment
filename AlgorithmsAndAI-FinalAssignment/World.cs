using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.Graph;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class World
    {
        /* Width of the Canvas */
        public int Width;

        /* Height of the Canvas*/
        public int Height;

        /* The agent that will perform Path Following */
        public MovingEntity? MainAgent;

        /* All the entities that will move around the canvas */
        public List<MovingEntity> MovingEntities;

        /* All the entities that will not move */
        public List<StaticEntity> StaticEntities;

        /* The graph on the canvas. This will be used for PathPlanning */
        public Graph graph;

        /* The fuzzy module that will be used for getting the best cargo for each shuttle */
        public FuzzyModule? BestCargoModule;
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            MovingEntities = new List<MovingEntity>();
            StaticEntities = new List<StaticEntity>();
            MainAgent = null;

            /* Set the FuzzyModule */
            BestCargoModule = WorldBuilder.SetupBestCargoModule();

            /* Generate all the Moving Entities and Static Entities */
            WorldBuilder.GenerateMovingEntities(this);
            WorldBuilder.GenerateStaticEntities(this);

            graph = new Graph(this);

        }
        public void Update(float delta)
        {
            MainAgent?.Update(delta);
            StaticEntities.ForEach(x => { x.Update(delta); });
            MovingEntities.ForEach(x => { x.Update(delta); });
        }
        public void Render(Graphics g)
        {
            MainAgent?.Render(g);
            StaticEntities.ForEach(x => { x.Render(g); });
            MovingEntities.ForEach(x => { x.Render(g); });

            if (Form1.GraphVisible)
            {
                graph.Render(g);
            }
        }

        /// <summary>
        /// A method to get specific MovingEntities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetMovingEntityListOf<T>() where T : MovingEntity
        {
            return MovingEntities.Where(e => e is T).Select(e => (T)e).ToList();
        }
        /// <summary>
        /// A method to get specific StaticEntities */
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetStaticEntityListOf<T>() where T : StaticEntity
        {
            return StaticEntities.Where(e => e is T).Select(e => (T)e).ToList();
        }


        /// <summary>
        /// Method to start Path finding Process
        /// </summary>
        /// <param name="vectorX"></param>
        /// <param name="vectorY"></param>
        public void StartPathPlanning(int vectorX, int vectorY)
        {
            /* Get the size between the nodes. This is needed to calculate the Node index */
            double size = Graph.BetweenNodes;

            /* The end node, the node of the clicked position */
            Node end = graph.NodeList[Convert.ToInt32(vectorX / size), Convert.ToInt32(vectorY / size)];

            /* If the end node does not exist or the MainAgent is not set. Do not start the AstarProcess */
            if (end != null && MainAgent != null)
            {
                Node start = graph.NodeList[Convert.ToInt32(MainAgent.Position.x / size), Convert.ToInt32((MainAgent.Position.y / size))];
                graph.AstarPath(start, end);
            }
        }

        //<summary>
        // A method that will be used to reposition a entity if it is out of the boundaries of the world.
        // The use of Math.Abs and the current position is to make the wrap around more fluently. 
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
