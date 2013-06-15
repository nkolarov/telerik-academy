// ********************************
// <copyright file="TrieImplementationDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TrieImplementation
{
    using System;
    using System.IO;

    /// <summary>
    /// Demonstrates trie usage.
    /// </summary>
    public class TrieImplementationDemo
    {
        /* 03. Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). Print how many times each word occurs in the text.
        Hint: you may find a C# trie in Internet.
        */
        public static void Main()
        {
            Trie trieStructure = new Trie();

            using (StreamReader inputFile = new StreamReader("../../fatFile.txt"))
            {
                string line = inputFile.ReadLine();

                while (line != null)
                {
                    InsertInTrie(trieStructure, line);
                    line = inputFile.ReadLine();
                }
            }
            // TODO: Implement searching.
        }

        /// <summary>
        /// Inserts the text in trie structure.
        /// </summary>
        /// <param name="trieStructure">The trie structure.</param>
        /// <param name="text">The text.</param>
        private static void InsertInTrie(Trie trieStructure, string text)
        {
            char[] separators = new char[] { ' ', ',', ';', '.' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                trieStructure.Insert(word);
            }
        }
    }
}