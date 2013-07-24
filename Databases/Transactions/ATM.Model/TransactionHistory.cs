// ********************************
// <copyright file="TransactionsHistory.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Model
{
    using System;

    /// <summary>
    /// Represents a transaction history.
    /// </summary>
    public class TransactionHistory
    {
        /// <summary>
        /// Stores the transaction id.
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Stores the transaction date time.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Stores the amount of transferred funds.
        /// </summary>
        public decimal Ammount { get; set; }

        /// <summary>
        /// Stores the card number.
        /// </summary>
        public string CardNumber { get; set; }
    }
}
