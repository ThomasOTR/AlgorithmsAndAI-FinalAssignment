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

        /* Contains the amount of Nodes on the X axis */
        private readonly double MaxX;

        /* Contains the amount of Nodes on the Y axis */
        private readonly double MaxY;

        /* The Nodes on their positions */
        public Node[,] NodeList;

        /* Path that is planned. Result of Astar PathPlanning */
        private readonly List<Node> ShortestPath;

        /* Nodes visited during Astar PathPlanning */
        private List<Node> NodesVisited;

        /* A boolean to check if the path is calculated. This helps for the drawing process */
        public bool PathCalculated;

        public Graph(World world)
        {
            ShortestPath = new List<Node>();
            NodesVisited = new List<Node>();

            this.world = world;
            MaxX = world.Width / BetweenNodes;
            MaxY = world.Height / BetweenNodes;
            NodeList = new Node[(int)(MaxX + 1), (int)(MaxY + 1)];

            PathCalculated = false;

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

        /// <summary>
        /// A method to check if a position of a node is within the range of a obstacle
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
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
                        /* Horizontal and Vertical lines*/
                        if (!IsOutOfRange(x - 1, y)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x - 1, y]));
                        if (!IsOutOfRange(x + 1, y)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x + 1, y]));
                        if (!IsOutOfRange(x, y + 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x, y + 1]));
                        if (!IsOutOfRange(x, y - 1)) NodeList[x, y].AddAdjecent(new Edge(NodeList[x, y - 1]));

                        /* Diagonal lines */
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

            if (PathCalculated)
            {
                if (ShortestPath.Count > 0 && NodesVisited.Count > 0) RenderAstar(g);
            }

        }

        /// <summary>
        /// Method to render the Graph
        /// </summary>
        /// <param name="g"></param>
        private void RenderGraph(Graphics g)
        {
            double maxX = world.Width / BetweenNodes;
            double maxY = world.Height / BetweenNodes;

            /* Loop through the grid */
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    if (NodeList[x, y] != null)
                    {
                        /* Render the Node*/
                        NodeList[x, y].Render(g, new Pen(Color.White));

                        /* Render the Edges of the node*/
                        foreach (Edge e in NodeList[x, y].GetAdjecents())
                        {
                            e.Render(g, NodeList[x, y].Position, new Pen(Color.DarkGray));
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
            /* Render the path */
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

            /* Render all the visited nodes */
            foreach (Node visitedNode in NodesVisited.ToList()) visitedNode.Render(g, new Pen(Color.Red, 3));
        }

        /// <summary>
        /// Method which will calculate the Astar Path
        /// </summary>
        /// <param name="start">Node of the start location</param>
        /// <param name="end">Node of the destination location</param>
        public void CalculatePathWithAstar(Node start, Node end)
        {
            PriorityQueue pq = new();

            /* Add the Start Node to the Priority Queue to start the process*/
            start.Known = true;
            pq.Insert(start);

            /* Loop through each item in the Queue until the end is found.*/
            while (!pq.Empty())
            {
                /* Get the node with the lowest F cost. */
                Node n = pq.Pop();

                /* Break the while loop when the node is null. */
                if (n == null) break;

                /* If the end node is found, break the while loop.*/
                if (n.Equals(end))
                {
                    break;
                }

                /* Add 1 to the current cost of the node. Needed for the Manhattan Heuristic  */
                double Cost = n.G + 1;

                /* Loop through each of the edges of the Node. */
                foreach (Edge e in n.GetAdjecents())
                {
                    /* If the Destination is already known, skip to next edge*/
                    Node Dest = e.Destination;
                    if (Dest.Known) continue;

                    Dest.Known = true;

                    /* Calculate the heuristic*/
                    double Heuristic = Math.Abs(Dest.Position.x - end.Position.x) + Math.Abs(Dest.Position.y - end.Position.y);

                    /* If the Destination is not added to the Priority Queue. Add it with the updated costs */
                    if (!pq.IsAlreadyAdded(Dest))
                    {
                        Dest.G = Cost;
                        Dest.F = Heuristic + Dest.G;
                        Dest.Prev = n;
                        pq.Insert(Dest);
                    }
                    /* If it's already added, check if the current cost + heuristic is lower than the F cost. This means this route is shorter. */
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
            /* Set the visited nodes, by getting all the nodes in the priority queue. */
            NodesVisited = pq.GetNodes();

            /* Calculate the shortest path */
            CalculateShortestPath(end);

        }

        private void CalculateShortestPath(Node end)
        {
            /* Start with the destination node */
            Node node = end;

            /* Navigate back to the start by .Prev */
            while (node != null)
            {
                ShortestPath.Add(node);
                node = node.Prev;
            }

            /* Set this on true helps drawing the path on the right moment */
            PathCalculated = true;

        }
        /// <summary>
        /// A method to reset the ShortestPath, VisitedNodes and the booleans.
        /// </summary>
        public void Reset()
        {
            PathCalculated = false;

            ShortestPath.ForEach(n => n.Reset());
            ShortestPath.Clear();

            NodesVisited.ForEach(n => n.Reset());
            NodesVisited.Clear();


        }
    }
}
