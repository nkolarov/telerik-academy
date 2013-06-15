// ********************************
// <copyright file="TrieNode.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TrieImplementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Trie Node.
    /// </summary>
    public class TrieNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrieNode" /> class.
        /// </summary>
        /// <param name="character">The character.</param>
        public TrieNode(char character)
        {
            this.ChildNode = new Dictionary<char, TrieNode>();
            this.IsLast = false;
            this.Letter = character;
        }

        /// <summary>
        /// Gets the letter.
        /// </summary>
        /// <value>The letter.</value>
        public char Letter { get; private set; }

        /// <summary>
        /// Gets or sets the isLast.
        /// </summary>
        /// <value>The is last.</value>
        public bool IsLast { get; set; }

        /// <summary>
        /// Gets or sets the child node.
        /// </summary>
        /// <value>The child node.</value>
        public Dictionary<char, TrieNode> ChildNode { get; set; }

        /// <summary>
        /// Gets the child node.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>The child node.</returns>
        public TrieNode GetChildNode(char character)
        {
            if (this.ChildNode != null)
            {
                if (this.ChildNode.ContainsKey(character))
                {
                    return this.ChildNode[character];
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal
        /// to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise,
        /// false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal
        /// to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise,
        /// false.
        /// </returns>
        public bool Equals(TrieNode obj)
        {
            if (obj != null &&
                obj.Letter == this.Letter)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            int hash = 11;
            hash = (hash * 6) + this.Letter.GetHashCode();
            return hash;
        }
    }
}