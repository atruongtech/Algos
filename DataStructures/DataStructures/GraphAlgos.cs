using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgos
{
    public class GraphNode
    {
        public int Id;
        public bool Visited;
    }

    public class Graph
    {
        public List<GraphNode> Nodes = new List<GraphNode>();
        public Dictionary<int, List<GraphNode>> Edges = new Dictionary<int, List<GraphNode>>();
    }

    public class BreadthFirst
    {
        public static void BreadthFirstTraversal(Graph graph)
        {
            Queue<GraphNode> visitQueue = new Queue<GraphNode>();
            visitQueue.Enqueue(graph.Nodes[0]);

            while (visitQueue.Count > 0)
            {
                GraphNode current = visitQueue.Dequeue();
                current.Visited = true;
                Console.WriteLine(current.Id);

                if (!graph.Edges.ContainsKey(current.Id))
                    continue;

                foreach (GraphNode neighbor in graph.Edges[current.Id])
                {
                    if (!visitQueue.Contains(neighbor) && !neighbor.Visited)
                        visitQueue.Enqueue(neighbor);
                }
            }

            foreach(var node in graph.Nodes)
            {
                if (!node.Visited)
                    Console.WriteLine("Node not visited: " + node.Id.ToString());
            }
        }
        
    }
}
