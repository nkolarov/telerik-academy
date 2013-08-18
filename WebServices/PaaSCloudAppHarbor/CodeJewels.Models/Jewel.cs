// ****************************************************************
// <copyright file="Jewel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace CodeJewels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a code jewel.
    /// </summary>
    public class Jewel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorMail { get; set; }

        [Required]
        public string SourceCode { get; set; }

        public Category Category { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public Jewel() 
        {
            this.Votes = new HashSet<Vote>();
        }
    }
}
