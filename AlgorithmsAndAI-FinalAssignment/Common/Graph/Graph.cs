using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class Graph
    {
        /* The world where the graph is used. Ideal to get specific properties*/
        private readonly World world;

        /* The pixel size between each node */
        public static readonly int BetweenNodes = 25;

        /* comtains the amount of Nodes on the X axis */
        private readonly double MaxX;

        /* contains the amount of nodes on the Y axis */
        private readonly double MaxY;

        /* The Nodes on their positions */
        public Node[,] NodeList;

        /* Path that is planned. Result of Astar PathPlanning */
        private readonly List<Node> ShortestPath;

        /* Nodes visited during Astar PathPlanning */
        private List<Node> NodesVisited;

        public Graph(World world)
        {
            ShortestPath = new List<Node>();
            NodesVisited = new List<Node>();
            this.world = world;
            MaxX = world.Width / BetweenNodes;
            MaxY = world.Height / BetweenNodes;
            NodeList = new Node[(int)(MaxX + 1), (int)(MaxY + 1)];
            CreateNodes();
            CreateEdges();
        }

        /// <summary>
        /// Method to Create Nodes and add them to the List.
        /// </summary>
        public void CreateNodes()
        {
            for (int x = 0; x <= MaxX; x++)
            {
                for (int y = 0; y <= MaxY; y++)
                {
                    if (InRadiusOfStaticEntity(new Vector2D(x * BetweenNodes, y * BetweenNodes))) continue;

                    NodeList[x, y] = new Node(new Vector2D(x * BetweenNodes, y * BetweenNodes));
                }
            }
        }
        public bool InRadiusOfStaticEntity(Vector2D v)
        {
            bool InRadius = false;
            foreach (StaticEntity SE in world.StaticEntities)
            {
                if (v.WithinRange(SE.Position, SE.radius))
                { InRadius = true; break; }
            }
            return InRadius;
        }

        /// <summary>
        /// Method to create Edges and add them to their nodes
        /// </summary>
        public void CreateEdges()
        {
            for (int x = 0; x <= MaxX; x++)
            {
                for (int y = 0; y <= MaxY; y++)
                {
                    if (NodeList[x, y] != null)
                    {

                        if (!IsOutOfRange(x - 1, y)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x - 1, y]));
                        if (!IsOutOfRange(x + 1, y)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x + 1, y]));
                        if (!IsOutOfRange(x, y + 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x, y + 1]));
                        if (!IsOutOfRange(x, y - 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x, y - 1]));


                        if (!IsOutOfRange(x - 1, y - 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x - 1, y - 1]));
                        if (!IsOutOfRange(x + 1, y - 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x + 1, y - 1]));
                        if (!IsOutOfRange(x - 1, y + 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x - 1, y + 1]));
                        if (!IsOutOfRange(x + 1, y + 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x + 1, y + 1]));


                    }
                }
            }
        }

        /// <summary>
        /// A method to check if specific coords are out of range.
        /// </summary>
        /// <param name="x">X position of Node </param>
        /// <param name="y">Y position of Node </param>
        /// <returns></returns>
        private bool IsOutOfRange(int x, int y)
        {
            if (x < 0 || y < 0) return true;
            else if (x > MaxX || y > MaxY) return true;
            else if (NodeList[x, y] == null) return true;
            else return false;
        }

        /// <summary>
        /// Method to get Shortest path;
        /// </summary>
        /// <returns></returns>
        public List<Node> GetShortestPath()
        {
            return ShortestPath;
        }

        /// <summary>
        /// Method to get Visited Nodes
        /// </summary>
        /// <returns></returns>
        public List<Node> GetVisitedNodes()
        {
            return NodesVisited;
        }

        /// <summary>
        /// Method to render everything related to Graph
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            RenderGraph(g);
            if (ShortestPath.Count > 0 && NodesVisited.Count > 0) RenderAstar(g);

        }

        /// <summary>
        /// Method to render the Graph
        /// </summary>
        /// <param name="g"></param>
        private void RenderGraph(Graphics g)
        {
            double maxX = world.Width / BetweenNodes;
            double maxY = world.Height / BetweenNodes;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (NodeList[x, y] != null)
                    {
                        NodeList[x, y].Render(g, new Pen(Color.White));
                        foreach (Edge e in NodeList[x, y].GetAdjecents())
                        {
                            e.Render(g, NodeList[x, y].Position, new Pen(Color.White));
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Method to render the Astar Path and visited Nodes
        /// </summary>
        /// <param name="g"></param>
        private void RenderAstar(Graphics g)
        {
            for (int i = 0; i < ShortestPath.Count; i++)
            {
                Node n = ShortestPath[i];
                n.Render(g, new Pen(Color.Orange, 3));
                if (i + 1 < ShortestPath.Count)
                {
                    Edge Temp = new(ShortestPath[i + 1]);
                    Temp.Render(g, n.Position, new Pen(Color.Green, 3));
                }
            }
            foreach (Node visitedNode in NodesVisited) visitedNode.Render(g, new Pen(Color.Red, 3));
        }

        /// <summary>
        /// Method which will calculate the Astar Path
        /// </summary>
        /// <param name="start">Node of the start location</param>
        /// <param name="end">Node of the destination location</param>
        public void AstarPath(Node start, Node end)
        {
            PriorityQueue pq = new();

            start.Known = true;
            pq.Insert(start);

            while (!pq.Empty())
            {
                Node n = pq.Pop();

                if (n == null) break;

                ShortestPath.Add(n);
                if (n.Equals(end))
                {
                    break;
                }

                double Cost = n.G + 1;

                foreach (Edge e in n.GetAdjecents())
                {
                    Node Dest = e.Destination;
                    if (Dest.Known) continue;

                    Dest.Known = true;
                    double Heuristic = Math.Abs(Dest.Position.x - end.Position.x) + Math.Abs(Dest.Position.y - end.Position.y);


                    if (!pq.IsAlreadyAdded(Dest))
                    {
                        Dest.G = Cost;
                        Dest.F = Heuristic + Dest.G;
                        Dest.Prev = n;
                        pq.Insert(Dest);
                    }
                    else
                    {

                        if (Cost + Dest.H < Dest.F)
                        {
                            Dest.G = Cost;
                            Dest.F = Dest.H + Dest.G;
                            Dest.Prev = n;
                        }
                    }
                }
            }
            NodesVisited = pq.GetNodes();
        }

        /// <summary>
        /// A method to reset the ShortestPath and VisitedNodes.
        /// </summary>
        public void Reset()
        {
            ShortestPath.ForEach(n => n.Reset());
            ShortestPath.Clear();

            NodesVisited.ForEach(n => n.Reset());
            NodesVisited.Clear();

        }
    }
}
