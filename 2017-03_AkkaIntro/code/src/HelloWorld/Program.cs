﻿using System;
using Akka.Actor;
using Shared.Messages;

namespace HelloWorld
{
    using Shared;

    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("HelloWorldSystem");

            var helloWorldActor = system.ActorOf(Props.Create<HelloWorldActor>(), "helloWorldActor");

            // NOTE: Could also use the Scheduler to send messages
            // It is done quickly this way for demo purposes.
            while (true) 
            {
                Console.WriteLine("Enter your name");
                var name = Console.ReadLine();
                if (name != null && name.ToLowerInvariant() == "end")
                {
                    helloWorldActor.Tell(new FinishedMessage());
                    break;
                }

                helloWorldActor.Tell(new HelloWorldMessage(name));
            }

            Console.WriteLine("Finished! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
