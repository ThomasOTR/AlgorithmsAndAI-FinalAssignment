using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class Node
    {
        /* A name for the node to easily identify the node */
        public string Name;

        /* Position of the node */
        public Vector2D Position;

        /* Previous node */
        public Node? Prev;

        /* Cumulative cost to reach a node */
        public double G;

        /* Heuristic */
        public double H;

        /* G + H */
        public double F;

        /* Edges of the Node. The connections to other nodes */
        private List<Edge> Adjecents;

        /* Property to check if this Node is already checked during Astar Process */
        public bool Known;

        public Node(Vector2D Position)
        {
            Name = $"{Position.x / Graph.BetweenNodes},{Position.y / Graph.BetweenNodes}";
            this.Position = Position;
            Adjecents = new List<Edge>(4);
            Prev = null;
            Known = false;
            G = 0.0;
            H = 0.0;
            F = 0.0;
        }

        /// <summary>
        /// Method to add Adjecent to node. 
        /// </summary>
        /// <param name="e"></param>
        public void AddAdjecent(Edge e)
        {
            Adjecents.Add(e);
        }
        /// <summary>
        /// Method to get adjecents.
        /// </summary>
        /// <returns></returns>
        public List<Edge> GetAdjecents()
        {
            return Adjecents;
        }

        /// <summary>
        /// Method to check if this node is equal to an other Node.
        /// </summary>
        /// <param name="other">The other node to compare</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to render Node.
        /// </summary>
        /// <param name="g">Graphics component to render the node</param>
        /// <param name="p">Pen that draws a node.</param>
        public void Render(Graphics g, Pen p)
        {
            Rectangle r = new Rectangle((int)Position.x - 2, (int)Position.y - 2, 4, 4);
            g.DrawRectangle(p, r);
        }

        /// <summary>
        /// Method to reset node after Astar Process;
        /// </summary>
        public void Reset()
        {
            F = 0.0;
            G = 0.0;
            H = 0.0;
            Prev = null;
            Known = false;
        }

    }
}
