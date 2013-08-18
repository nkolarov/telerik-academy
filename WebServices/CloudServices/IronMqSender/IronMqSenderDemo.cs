// ****************************************************************
// <copyright file="IronMqSenderDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace IronMqSender
{
    using System;
    using IronMQ;

    public class IronMqSenderDemo
    {
        private const string PROJECT_ID = "5210d34bec920c000d000005";
        private const string TOKEN = "aNWX6SqOC0NDQVVrr9KyA96nwGs";
        private const string CHAT_NAME = "Secret Ninja Chat";

        static void Main()
        {

            Client chatClient = new Client(PROJECT_ID, TOKEN);
            IQueue queue = chatClient.Queue(CHAT_NAME);

            Console.WriteLine("You entered in: " + CHAT_NAME);

            while (true)
            {
                Console.WriteLine("Enter a message to send: ");
                var message = Console.ReadLine();
                queue.Push(message);
                Console.WriteLine("Message sent!");
            }
        }
    }
}
