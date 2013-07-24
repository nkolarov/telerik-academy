// ********************************
// <copyright file="CardAccountMappings.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using ATM.Model;

    /// <summary>
    /// Defines card account column mappings.
    /// </summary>
    public class CardAccountMappings: EntityTypeConfiguration<CardAccount>
    {
        public CardAccountMappings() 
        {
            this.HasKey(ca => ca.CardAccountId);
            this.Property(ca => ca.CardNumber).HasColumnType("char").HasMaxLength(10).IsRequired();
            this.Property(ca => ca.CardCash).IsRequired();
            this.Property(ca => ca.CardPIN).HasColumnType("char").HasMaxLength(4).IsRequired();
        }
    }
}
