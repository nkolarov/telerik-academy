// ********************************
// <copyright file="DAOTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Northwind.DAO
{
    using System;
    using System.Linq;
    using Northwind.Model;
    using Northwind.DAO;

    public class DAOTest
    {
        /* 02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            var pesho = new Customer
            {
                CustomerID = "ZzPS3",
                CompanyName = "TElerikAcademy",
                ContactName = "Pesho",
                ContactTitle = "Ninja",
            };

            DAO.AddCustomer(pesho);

            pesho.ContactTitle = "AcademyNinja";

            DAO.UpdateCustomer(pesho);

            DAO.DeleteCustomer(pesho);

        }
    }
}
