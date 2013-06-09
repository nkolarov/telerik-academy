// ********************************
// <copyright file="LinkedList.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace LinkedListDemoImplementation
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents Linked List.
    /// </summary>
    public class LinkedList<T>
    {
        /// <summary>
        /// Gets or sets the first element.
        /// </summary>
        /// <value>The first element.</value>
        public ListItem<T> FirstElement { get; set; }

        /// <summary>
        /// Gets or sets the last element.
        /// </summary>
        /// <value>The last element.</value>
        public ListItem<T> LastElement { get; set; }

        /// <summary>
        /// Gets the count of elements in the list.
        /// </summary>
        public int Count
        {
            get
            {
                return this.GetCount();
            }
        }

        /// <summary>
        /// Adds an element at first position.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddFirst(T value) 
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
                this.LastElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(value);
                newItem.NextItem = this.FirstElement;
                this.FirstElement = newItem;
            }
        }

        /// <summary>
        /// Adds an element after the last one.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddLast(T value)
        {
            if (this.LastElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
                this.LastElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(value);
                ListItem<T> current = this.FirstElement;

                // Look for the last element.
                while (current.NextItem != null)
                {
                    current = current.NextItem;
                }

                current.NextItem = newItem;
            }
        }

        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Remove(T value)
        {
            if (this.FirstElement == null)
            {
                throw new InvalidOperationException("You can not remove an element from an empty list!");
            }

            ListItem<T> current = this.FirstElement;
            ListItem<T> previuos = null;
            while (current != null)
            {
                if ((dynamic)current.Value == (dynamic)value)
                {
                    if (previuos == null)
                    {
                        this.FirstElement = this.FirstElement.NextItem;
                    }
                    else
                    {
                        previuos.NextItem = current.NextItem;
                    }
                }

                previuos = current;
                current = current.NextItem;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (this.FirstElement == null)
            {
                return "Empty list!";
            }

            StringBuilder result = new StringBuilder();
            ListItem<T> current = this.FirstElement;

            result.AppendLine(current.Value.ToString());

            while (current.NextItem != null)
            {
                current = current.NextItem;
                result.AppendLine(current.Value.ToString());
            }

            return result.ToString();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>The count.</returns>
        private int GetCount()
        {
            if (this.FirstElement == null)
            {
                return 0;
            }

            ListItem<T> current = this.FirstElement;
            int count = 1;
            while (current.NextItem != null)
            {
                count++;
                current = current.NextItem;
            }

            return count;
        }
    }
}