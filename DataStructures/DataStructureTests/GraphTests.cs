using System;
using NUnit.Framework;
using GraphAlgos;
using System.Collections.Generic;

namespace DataStructureTests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void BreadthFirstTraversal_Sets_Visited()
        {
            Graph graph = new Graph();
            var node1 = new GraphNode() { Id = 1 };
            var node2 = new GraphNode() { Id = 2 };
            var node3 = new GraphNode() { Id = 3 };
            var node4 = new GraphNode() { Id = 4 };

            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);
            graph.Nodes.Add(node4);

            graph.Edges.Add(1, new List<GraphNode>());
            graph.Edges.Add(2, new List<GraphNode>());

            graph.Edges[1].Add(node2);
            graph.Edges[1].Add(node4);
            graph.Edges[2].Add(node3);
            graph.Edges[2].Add(node4);

            BreadthFirst.BreadthFirstTraversal(graph);
            int count = 0;
            foreach(GraphNode node in graph.Nodes)
            {
                if (!node.Visited)
                    count++;
            }

            Assert.Zero(count);
        }

        [Test]
        public void BreadthFirstTraversal_DoesNot_Set_Visited_If_Unreachable()
        {
            Graph graph = new Graph();
            var node1 = new GraphNode() { Id = 1 };
            var node2 = new GraphNode() { Id = 2 };
            var node3 = new GraphNode() { Id = 3 };
            var node4 = new GraphNode() { Id = 4 };

            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);
            graph.Nodes.Add(node4);

            graph.Edges.Add(1, new List<GraphNode>());
            graph.Edges.Add(2, new List<GraphNode>());

            graph.Edges[1].Add(node2);
            graph.Edges[1].Add(node4);
            graph.Edges[2].Add(node4);

            BreadthFirst.BreadthFirstTraversal(graph);
            int count = 0;
            foreach (GraphNode node in graph.Nodes)
            {
                if (!node.Visited)
                    count++;
            }

            Assert.AreEqual(1,count);

        }
    }
}
