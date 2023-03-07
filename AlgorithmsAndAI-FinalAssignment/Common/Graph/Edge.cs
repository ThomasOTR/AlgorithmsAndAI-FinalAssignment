using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    /// <summary>
    /// A class which connects 2 nodes.
    /// </summary>
    public class Edge
    {
        /* Destination of the Edge */
        public Node Destination;
        public Edge(Node Destination)
        {
            this.Destination = Destination;
        }
        /// <summary>
        /// Method to render the edge
        /// </summary>
        /// <param name="g"> Graphics component to draw the line</param>
        /// <param name="Origin">The origin of the Edge.</param>
        /// <param name="p">A pen that can differ for each usecase </param>
        public void Render(Graphics g, Vector2D Origin, Pen p)
        {
            g.DrawLine(p, (int)Origin.x, (int)Origin.y, (int)Destination.Position.x, (int)Destination.Position.y);
        }

    }
}
