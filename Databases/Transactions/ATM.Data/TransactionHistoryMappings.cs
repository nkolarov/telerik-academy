// ********************************
// <copyright file="TransactionHistoryMappings.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using ATM.Model;

    /// <summary>
    /// Defines transaction history column mappings.
    /// </summary>
    public class TransactionHistoryMappings : EntityTypeConfiguration<TransactionHistory>
    {
        public TransactionHistoryMappings()
        {
            this.HasKey(x => x.TransactionId);
            this.Property(th => th.Ammount).IsRequired();
            this.Property(th => th.CardNumber).HasColumnType("char").HasMaxLength(10).IsRequired();
            this.Property(th => th.TransactionDate).IsRequired();
        }
    }
}
