// ********************************
// <copyright file="CallStoredProcedure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Accounts.Model
{
    using System;
    using System.Linq;
    using System.Transactions;

    /// <summary>
    /// Demonstrates how to add a user using transactions.
    /// </summary>
    public class AddUserDemo
    {
        /* 11. Create a database holding users and groups. Create a transactional EF based method that creates an user and puts it in a group "Admins". 
         * In case the group "Admins" do not exist, create the group in the same transaction.
         * If some of the operations fail (e.g. the username already exist), cancel the entire transaction.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            AddAdminUser("Pesho");
        }

        private static void AddAdminUser(string name)
        {
            var user = new User
            {
                UserName = name
            };

            using (var accountsDbContext = new AccountsEntities())
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    try
                    {
                        // Check if admins group exists.
                        var userGroup = accountsDbContext.Groups.FirstOrDefault(g => g.GroupName == "Admins");
                        if (userGroup == null)
                        {
                            accountsDbContext.Groups.Add(new Group { GroupName = "Admins" });
                            accountsDbContext.SaveChanges();
                        }

                        // Set user group
                        var adminGrouId = accountsDbContext.Groups.First(g => g.GroupName == "Admins");
                        user.GroupId = adminGrouId.GroupId;

                        // Save user
                        accountsDbContext.Users.Add(user);
                        accountsDbContext.SaveChanges();
                        trans.Complete();
                        Console.WriteLine("Done!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error! User not added! Try again! Error message: " + ex.Message);
                    }
                }
            }
        }
    }
}

