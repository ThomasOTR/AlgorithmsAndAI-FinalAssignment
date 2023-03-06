using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Graph
{
    public class PriorityQueue
    {
        private List<Node> nodes;
        public PriorityQueue() {
           nodes = new List<Node>();
        }

        public void Insert(Node n)
        {
            nodes.Add(n);
        }
        public Node Pop()
        {
            Node n = nodes.OrderBy(n => n.F).First();
            nodes.Remove(n);
            return n;
        }
        public bool Empty()
        {
            return nodes.Count == 0;
        }
        public bool IsAlreadyAdded(Node n)
        {
            return nodes.Any(node => node.Equals(n));
        }
        public List<Node> GetNodes()
        {
            return nodes;
        }

    }
}
