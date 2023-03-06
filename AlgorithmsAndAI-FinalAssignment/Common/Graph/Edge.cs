using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class Edge
    {
        public Node Destination;
        public Edge(Node Destination) 
        {
            this.Destination = Destination;
        }
        public void Render(Graphics g, Vector2D Origin,Pen p)
        {
            g.DrawLine(p, (int)Origin.x, (int)Origin.y, (int)Destination.Position.x, (int)Destination.Position.y);
        }
        
    }
}
