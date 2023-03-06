using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class Node
    {
        /* A name for the node to easily identify the node */
        public string Name;

        public Vector2D Position;

        public Node? Prev;

        public double G; // Cumulative cost to reach a node

        public double H; // Heuristic

        public double F; // G + H

        private List<Edge> Adjecents;

        public bool Known;

        public Node(Vector2D Position) 
        {
            Name = $"{Position.x / NavigationGraph.distanceBetweenNodes},{Position.y / NavigationGraph.distanceBetweenNodes}";
            this.Position= Position;
            Adjecents = new List<Edge>(4);
            Prev = null;
            Known = false;
            G = 0.0;
            H = 0.0;
            F = 0.0;
        }
        public void AddAdjecent(Edge e)
        {
            //if (e.Destination == null) return;
            Adjecents.Add(e);
        }
        public List<Edge> GetAdjecents()
        {
            return Adjecents;
        }
        public bool Equals(Node other)
        {
            return (
                Name.Equals(other.Name) &&
                Adjecents.Count == other.Adjecents.Count &&
                G.Equals(other.G) &&
                H.Equals(other.H) &&
                Position.Equals(other.Position)
                );
        }
        public void Render(Graphics g, Pen p)
        {
            Rectangle r = new Rectangle((int)Position.x - 2, (int)Position.y - 2, 4, 4);
            g.DrawRectangle(p, r);
        }


    }
}
