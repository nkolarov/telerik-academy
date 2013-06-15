// ********************************
// <copyright file="Trie.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TrieImplementation
{
    using System;

    /// <summary>
    /// Represents a Trie.
    /// </summary>
    public class Trie
    {
        /// <summary>
        /// Stores the root trie node.
        /// </summary>
        private TrieNode rootNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie" /> class.
        /// </summary>
        public Trie()
        {
            this.rootNode = new TrieNode(' ');
        }

        /// <summary>
        /// Inserts the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        public void Insert(string word)
        {
            char[] wordCharacters = word.ToLower().ToCharArray();

            TrieNode current = this.rootNode;

            if (wordCharacters.Length == 0)
            {
                current.IsLast = true;
            }

            for (int i = 0; i < word.Length; i++)
            {
                TrieNode child = current.GetChildNode(wordCharacters[i]);
                if (child != null)
                {
                    current = child;
                }
                else
                {
                    current.ChildNode.Add(wordCharacters[i], new TrieNode(wordCharacters[i]));
                    current = current.GetChildNode(wordCharacters[i]);
                }

                if (i == wordCharacters.Length - 1)
                {
                    current.IsLast = true;
                }
            }
        }

        /// <summary>
        /// Searches the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>True or false depending if the word exists.</returns>
        public bool Search(string word)
        {
            char[] wordCharacters = word.ToLower().ToCharArray();
            TrieNode current = this.rootNode;
            while (current != null)
            {
                for (int i = 0; i < wordCharacters.Length; i++)
                {
                    if (current.GetChildNode(wordCharacters[i]) == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.GetChildNode(wordCharacters[i]);
                    }
                }

                if (current.IsLast == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}