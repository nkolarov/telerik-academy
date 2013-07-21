// ********************************
// <copyright file="EmployeeExtend.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Northwind.Model
{
    using System;
    using System.Data.Linq;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extends employee functionality.
    /// </summary>
    public partial class Employee
    {
        #region AddTerritoriesProperty
        private EntitySet<Territory> territoriesSet = new EntitySet<Territory>();

        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                EntitySet<Territory> territoriesSet = new EntitySet<Territory>();
                this.territoriesSet.AddRange(this.Territories);

                return this.territoriesSet;
            }
        }
        #endregion  
    }
}