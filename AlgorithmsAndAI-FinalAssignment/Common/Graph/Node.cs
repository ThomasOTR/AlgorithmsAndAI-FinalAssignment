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

        public double Distance;

        public double Heuristic;

        public double DistancePlusHeuristic;

        private List<Edge> Adjecents;

        public Node(Vector2D Position) 
        {
            Name = $"{Position.x / Graph.distanceBetweenNodes},{Position.y / Graph.distanceBetweenNodes}";
            this.Position= Position;
            Adjecents = new List<Edge>(4);
            Prev = null;

            Distance = 0.0;
            Heuristic = double.PositiveInfinity;
            DistancePlusHeuristic = 0.0;
        }
        public void AddAdjecent(Edge e)
        {
            if (!Adjecents.Any(a => a.Destination.Equals(e.Destination)))
            { 
                Adjecents.Add(e);
            }
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
                Distance.Equals(other.Distance) &&
                Heuristic.Equals(other.Heuristic) &&
                Position.Equals(other.Position)
                );
        }
        public void Render(Graphics g)
        {
            Rectangle r = new Rectangle((int)Position.x - 2, (int)Position.y - 2, 4, 4);
            g.DrawRectangle(new Pen(Color.Green), r);
        }


    }
}
