namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class PriorityQueue
    {
        /* Nodes of Priority Queue*/
        private List<Node> nodes;
        public PriorityQueue()
        {
            nodes = new List<Node>();
        }

        /// <summary>
        /// Insert a node into the Priority Queue.
        /// </summary>
        /// <param name="n"></param>
        public void Insert(Node n)
        {
            nodes.Add(n);
        }

        /// <summary>
        /// Pop the node with the lowest F value (Heuristic + Distance)
        /// </summary>
        /// <returns></returns>
        public Node Pop()
        {
            Node n = nodes.OrderBy(n => n.F).First();
            nodes.Remove(n);
            return n;
        }
        /// <summary>
        /// Method to check if nodes list is empty.
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            return nodes.Count == 0;
        }

        /// <summary>
        /// Method to check if a node is already added.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsAlreadyAdded(Node n)
        {
            return nodes.Any(node => node.Equals(n));
        }
        /// <summary>
        /// Method to get nodes.
        /// </summary>
        /// <returns></returns>
        public List<Node> GetNodes()
        {
            return nodes;
        }

    }
}
