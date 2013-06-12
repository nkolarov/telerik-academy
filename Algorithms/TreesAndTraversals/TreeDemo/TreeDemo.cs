// ********************************
// <copyright file="TreeDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TreeDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates Tree Traversal.
    /// </summary>
    public class TreeDemo
    {
        /* 01. You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1).*/
        static int N;
        static Node<int>[] nodes;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            ReadTreeDataFromConsole();

            // a) Write a program to find the root node.
            var root = GetRoot(nodes);
            Console.WriteLine("Root: " + root.Value);

            // b) Write a program to find all leaf nodes.
            var leafs = GetAllLeafs(nodes);
            Console.WriteLine("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.WriteLine(leaf.Value);
            }

            // c) Write a program to find all middle nodes
            var middleNodes = GetAllMiddleNodes(nodes);
            if (middleNodes.Count > 0)
            {
                Console.WriteLine("Middle nodes: ");
                foreach (var middleNode in middleNodes)
                {
                    Console.WriteLine(middleNode.Value);
                }
            }

            // d) Write a program to find the longest path in the tree
            var longestPathCount = GetLongestPathCount(GetRoot(nodes));
            Console.WriteLine("Longest path count: ");
            Console.WriteLine(longestPathCount);
        }
  
        /// <summary>
        /// Reads the tree data from console.
        /// </summary>
        private static void ReadTreeDataFromConsole()
        {
            N = int.Parse(Console.ReadLine());
            nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parrentId = int.Parse(edgeParts[0]);
                int childrenId = int.Parse(edgeParts[1]);

                nodes[parrentId].Children.Add(nodes[childrenId]);
                nodes[childrenId].HasParent = true;
            }
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns></returns>
        private static Node<int> GetRoot(Node<int>[] nodes)
        {
            bool[] hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < nodes.Length; i++)
            {
                if (hasParent[i] == false)
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("The tree doesn`t have a root!");
        }

        /// <summary>
        /// Gets all leafs.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns>The leafs.</returns>
        private static List<Node<int>> GetAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        /// <summary>
        /// Gets all middle nodes.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns>The middle nodes.</returns>
        private static List<Node<int>> GetAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();
            var root = GetRoot(nodes);
            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        /// <summary>
        /// Gets the longest path count.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>The count of the longest path.</returns>
        private static int GetLongestPathCount(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, GetLongestPathCount(node));
            }
            
            return maxPath + 1;
        }
    }
}