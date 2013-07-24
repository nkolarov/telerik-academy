// ********************************
// <copyright file="CardAccount.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Model
{
    using System;

    /// <summary>
    /// Represents a card account.
    /// </summary>
    public class CardAccount
    {
        public int CardAccountId { get; set; }

        public string CardNumber { get; set; }

        public string CardPIN { get; set; }

        public decimal CardCash { get; set; }

    }
}
