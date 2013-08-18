// ****************************************************************
// <copyright file="IronMqReceiverDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace IronMqReceiver
{
    using IronMQ;
    using IronMQ.Data;
    using System;
    using System.Threading;

    public class IronMqReceiverDemo
    {
        /* 01. Implement a very simple chat application based on some message queue service:
            Users can send message into a common channel.
            Messages are displayed in the format {IP : message_text}.
            Use a language, cloud and message queue service of your choice (e.g. C# + AppHarbor + IronMQ). Your application can be console, GUI or Web-based.*/

        private const string PROJECT_ID = "5210d34bec920c000d000005";
        private const string TOKEN = "aNWX6SqOC0NDQVVrr9KyA96nwGs";
        private const string CHAT_NAME = "Secret Ninja Chat";

        static void Main()
        {
            Client chatClient = new Client(PROJECT_ID, TOKEN);
            IQueue queue = chatClient.Queue(CHAT_NAME);

            Console.WriteLine("You entered in: " + CHAT_NAME);
            Console.WriteLine("Listening for new messages...");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }

                Thread.Sleep(100);
            }
        }
    }
}
