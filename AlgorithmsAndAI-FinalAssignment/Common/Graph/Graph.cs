using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class Graph
    {
        private World world;
        public static double distanceBetweenNodes = 25;
        private double MaxX;
        private double MaxY;
        public Node[,] NodeList;
        public Graph(World world)
        {
            this.world = world;
            MaxX = world.Width / distanceBetweenNodes;
            MaxY = world.Height / distanceBetweenNodes;
            NodeList = new Node[(int)(MaxX + 1), (int)(MaxX + 1)];
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

                    }
                }
            }
        }
        private bool IsOutOfRange(int x, int y)
        {
            if (x < 0 || y < 0) return true;
            else if (x > MaxX || y > MaxY) return true;
            else return false;
        }

        public void Render(Graphics g)
        {
            double maxX = world.Width / distanceBetweenNodes;
            double maxY = world.Height / distanceBetweenNodes;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (NodeList[x, y] != null)
                    {
                        NodeList[x, y].Render(g);
                        foreach(Edge e in NodeList[x,y].GetAdjecents())
                        {
                            e.Render(g, NodeList[x,y].Position); 
                        }
                    }
                    
                }
            }
        }
    }
}
