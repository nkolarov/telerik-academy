// ****************************************************************
// <copyright file="Mark.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace CodeJewels.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Represents a vote.
    /// </summary>
    [DataContract]
    public class Vote
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [Range(0, 5)]
        public int Value { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }
}
