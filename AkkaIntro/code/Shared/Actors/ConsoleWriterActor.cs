using System;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class ConsoleWriterActor : ReceiveActor
    {
        public ConsoleWriterActor()
        {
            Receive<WriteSomethingMessage>(message =>
            {
                Console.WriteLine("[{0}]: {1}", Sender.Path, message.ThingToWrite);
            });
        }
    }
}