using System;
using Akka;
using Akka.Actor;
using Shared;
using Shared.Messages;

namespace HelloWorld
{
    public class HelloWorldActor : ReceiveActor
    {
        public HelloWorldActor()
        {
            Receive<HelloWorldMessage>(message =>
            {
                Console.WriteLine("Hello, {0}", message.Name);
            });

            Receive<FinishedMessage>(message =>
            {
                Console.WriteLine("I guess we're done here!");
            });
        }
    }
}