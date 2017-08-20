using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_dfs_bfs
{
    class Graph
    {
        Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
        
        public class Node
        {
            public int id;
            public LinkedList<Node> adjacent = new LinkedList<Node>();
            public Node(int id)
            {
                this.id = id;
            }
        }

        private Node getNode(int id)
        {
            if (nodeLookup.ContainsKey(id))
            {
                return nodeLookup[id];
            }

            var n = new Node(id);
            nodeLookup.Add(id, n);
            return n;
        }

        public void addEdge(int source, int destination)
        {
            Node s = getNode(source);
            Node d = getNode(destination);
            s.adjacent.AddLast(d);
        }

        public bool hasPathDFS(int source, int dest)
        {
            var s = getNode(source);
            var d = getNode(dest);
            HashSet<int> visites = new HashSet<int>();
            return hasPathDfsRecursive(s, d, visites);
        }

        private bool hasPathDfsRecursive(Node src, Node dest, HashSet<int> visited)
        {
            if (visited.Contains(src.id)) return false;
            visited.Add(src.id);

            if (src == dest)
            {
                return true;
            }
            foreach (Node child in src.adjacent)
            {
                if (hasPathDfsRecursive(child, dest, visited))
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasPathBFS(int srcid, int destid)
        {
            Node src = getNode(srcid);
            Node dest = getNode(destid);
            LinkedList<Node> nextToVist = new LinkedList<Node>();
            HashSet<int> visited = new HashSet<int>();
            nextToVist.AddLast(src);
            while (nextToVist.Count != 0)
            {
                var node = nextToVist.First.Value;
                nextToVist.RemoveFirst();
                if (node == dest)
                {
                    return true;
                }
                if (!visited.Contains(node.id))
                {
                    visited.Add(node.id);
                } else
                {
                    continue;
                }
                foreach (var child in node.adjacent)
                {
                    nextToVist.AddFirst(child);
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 3);
            g.addEdge(3, 5);
            g.addEdge(3, 6);
            g.addEdge(6, 1);
            var res = g.hasPathDFS(3, 2);
            res = g.hasPathBFS(3, 2);
            g.addEdge(5, 0);
            res = g.hasPathDFS(3, 2);
            res = g.hasPathBFS(3, 2);
        }
    }
}
