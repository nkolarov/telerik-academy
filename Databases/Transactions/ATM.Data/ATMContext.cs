// ********************************
// <copyright file="ATMContext.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Data
{
    using ATM.Model;
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Represents the ATM DB Context.
    /// </summary>
    public class ATMContext : DbContext
    {
        public ATMContext() : base("ATM")
        { }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionHistory> TransactionsHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CardAccountMappings());
            modelBuilder.Configurations.Add(new TransactionHistoryMappings());
            base.OnModelCreating(modelBuilder);
        }
    }
}
