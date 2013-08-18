// ****************************************************************
// <copyright file="PubNubChatDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace PubNubChat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    public class PubNubChatDemo
    {
        /* 02. Implement a very simple chat application based on some message queue service:
            Users can send message into a common channel.
            Messages are displayed in the format {IP : message_text}.
            Use PubNub. Your application can be console, GUI or Web-based.*/

        static void Main()
        {
            Process.Start("..\\..\\PubNubChatDemo.html");

            System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-e485b33f-6d32-4410-9cb8-98c61a4a48df",               // PUBLISH_KEY
                "sub-c-44c8865e-0817-11e3-ab8d-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-NWQwNjFmY2EtNzljMy00MGU2LTk4YjYtMWQwZThmM2U1Mjcw",   // SECRET_KEY
                false                                                        // SSL_ON?
            );
            string channel = "secret-ninja-channel";

            // Publish a sample message to Pubnub
            List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]
            );

            // Show PubNub server time
            object serverTime = pubnub.Time();

            Console.WriteLine("Server Time: " + serverTime.ToString());

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate(object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);
                Console.WriteLine("Message {0} sent.", msg);
            }
        }
    }
}
