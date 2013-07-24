// ********************************
// <copyright file="ATMDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ATM.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;
    using ATM.Data;
    using ATM.Data.Migrations;
    using ATM.Model;

    /// <summary>
    /// Demonstrates ATM usage demo.
    /// </summary>
    public class ATMDemo
    {
        /* 01. Suppose you are creating a simple engine for an ATM machine. 
           Create a new database "ATM" in SQL Server to hold the accounts of the card holders and the balance (money) for each account. 
           Add a new table CardAccounts with the following fields: 
	            Id (int)
	            CardNumber (char(10))
	            CardPIN (char(4))
	            CardCash (money)
           Add a few sample records in the table.*/
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
            TryToRetrieveSomeCash();
        }

        /// <summary>
        /// Tests RetrieveMoney correct working.
        /// </summary>
        private static void TryToRetrieveSomeCash()
        {
            string cardNumber = "0001";
            string cardPIN = "1211";
            decimal sum = 10;

            // Wrong PIN
            Console.WriteLine("First try: ");
            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error!" + ex.Message);
            }

            // Correct PIN. No money.
            cardPIN = "1111";
            sum = 1000;
            Console.WriteLine("Second try: ");
            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error!" + ex.Message);
            }

            // Get 10 bucks.
            Console.WriteLine("Third try: ");
            sum = 10;
            try
            {
                WithdrawMoney(cardNumber, cardPIN, sum);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error!" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves money from the ATM.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="PINCode">The pin code.</param>
        /// <param name="sum">The sum.</param>
        private static void WithdrawMoney(string cardNumber, string PINCode, decimal sum)
        {
            /* 02. Using transactions write a method which retrieves some money (for example $200) from certain account. 
             * The retrieval is successful when the following sequence of sub-operations is completed successfully:
             * A query checks if the given CardPIN and CardNumber are valid.
             * The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
             * The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).*/

            /* 03. Extend the project from the previous exercise and add a new table TransactionsHistory 
             * with fields (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
             * Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
             * What should the isolation level be for the transaction?*/
            using (var atmDbContext = new ATMContext())
            {
                // We work with money - so we use Repetable read.
                TransactionOptions tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = IsolationLevel.RepeatableRead;

                using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                {
                    var account = atmDbContext.CardAccounts.Where(ca => ca.CardNumber == cardNumber && ca.CardPIN == PINCode).FirstOrDefault();
                    if (account == null)
                    {
                        throw new InvalidOperationException("Card does not exists or PIN is wrong!");
                    }

                    if (sum <= 0)
                    {
                        throw new InvalidOperationException("Invalid sum!");
                    }

                    if (account.CardCash < sum)
                    {
                        throw new InvalidOperationException("Not enough minerals!");
                    }

                    // The ATM machine pays the required sum
                    ShowMeTheMoney(sum); 

                    // Update the account balance.
                    account.CardCash = account.CardCash - sum; 

                    // Saves the transaction to a log. 
                    LogTransaction(sum, account.CardNumber);

                    atmDbContext.SaveChanges();
                    tran.Complete();
                }
            }
        }

        /// <summary>
        /// Saves the transaction to a log.
        /// </summary>
        /// <param name="sum">The sum.</param>
        /// <param name="cardNumber">The card number.</param>
        private static void LogTransaction(decimal sum, string cardNumber)
        {
            using (var atmDbContext = new ATMContext())
            {
                TransactionHistory tranLog = new TransactionHistory
                {
                    CardNumber = cardNumber,
                    Ammount = sum,
                    TransactionDate = DateTime.Now,
                };

                atmDbContext.TransactionsHistory.Add(tranLog);
                atmDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gives the ATM a command to pull out the money.
        /// </summary>
        /// <param name="sum">The sum</param>
        private static void ShowMeTheMoney(decimal sum)
        {
            Console.WriteLine("Here you are some money: {0} bucks!", sum);
        }
    }
}
