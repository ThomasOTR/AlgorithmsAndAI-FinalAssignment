﻿using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{



    public class NavigationGraph
    {
        private World world;
        public static double distanceBetweenNodes = 25;
        private double MaxX;
        private double MaxY;
        public Node[,] NodeList;
        private List<Node> ShortestPath = new List<Node>();
        private List<Node> NodesVisited= new List<Node>();

        

        public NavigationGraph(World world)
        {
            this.world = world;
            MaxX = world.Width / distanceBetweenNodes;
            MaxY = world.Height / distanceBetweenNodes;
            NodeList = new Node[(int)(MaxX + 1), (int)(MaxY + 1)];
            CreateNodes();
            CreateEdges();
        }
        public void CreateNodes()
        {
            for (int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
                {
                    NodeList[x, y] = new Node(new Vector2D(x * distanceBetweenNodes, y * distanceBetweenNodes));
                }
            }
        }
        public void CreateEdges()
        {
            for (int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
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
        private bool IsOutOfRange(int x, int y)
        {
            
            if (x < 0 || y < 0) return true;
            else if (x > MaxX || y > MaxY) return true;
            else if (NodeList[x,y] == null) return true;
            else return false;
        }

        public List<Node> GetShortestPath()
        {
            return ShortestPath;
        }
        public List<Node> GetVisitedNodes()
        {
            return NodesVisited;
        }
        public void Render(Graphics g)
        {
            RenderGraph(g);
            if (ShortestPath.Count > 0 && NodesVisited.Count > 0) RenderAstar(g);

        }
        private void RenderGraph(Graphics g)
        {
            double maxX = world.Width / distanceBetweenNodes;
            double maxY = world.Height / distanceBetweenNodes;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (NodeList[x, y] != null)
                    {
                        NodeList[x, y].Render(g,new Pen(Color.Black));
                        foreach (Edge e in NodeList[x, y].GetAdjecents())
                        {
                            e.Render(g, NodeList[x, y].Position,new Pen(Color.Black));
                        }
                    }

                }
            }
        }
        private void RenderAstar(Graphics g)
        {
            for (int i = 0; i < ShortestPath.Count(); i++)
            {
                Node n = ShortestPath[i];
                n.Render(g, new Pen(Color.Orange,3));
                if (i + 1 < ShortestPath.Count())
                {
                    Edge Temp = new Edge(ShortestPath[i + 1]);
                    Temp.Render(g, n.Position, new Pen(Color.Green,3));
                }
            }
            foreach (Node visitedNode in NodesVisited) visitedNode.Render(g, new Pen(Color.Red,3));
        }
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
                if(n.Equals(end)) {
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
            System.Diagnostics.Debug.WriteLine("done ");
            CreatePath(start,end,pq.GetNodes());
        }
        private void CreatePath(Node startnode,Node endnode,List<Node>PQ_List)
        {
            List<Node> Path = new List<Node>();
            Node n = endnode;
            while(n != null)
            {
                System.Diagnostics.Debug.WriteLine(n.Name);
                Path.Add(n);
                n = n.Prev;
            }
            Path.Reverse();

            NodesVisited = PQ_List;
            System.Diagnostics.Debug.WriteLine("Path created");

            /* Reset nodes */

        }
    }
}
