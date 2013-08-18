// ****************************************************************
// <copyright file="JewelModel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace CodeJewels.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VoteModel
    {
        public int Id { get; set; }

        [Range(0, 5)]
        public int Value { get; set; }

        public string Email { get; set; }
    }
}