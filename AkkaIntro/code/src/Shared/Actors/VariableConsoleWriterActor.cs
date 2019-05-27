using System;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class VariableConsoleWriterActor : ReceiveActor, IWithUnboundedStash
    {
        public VariableConsoleWriterActor()
        {
            Become(NormalWriter);
        }
        public void NormalWriter()
        {
            Receive<WriteSomethingMessage>(message =>
            {
                if (message.ThingToWrite.ToLowerInvariant() == "be quiet")
                {
                    Console.WriteLine("zipping my lips!");
                    Become(QuietWriter);
                }
                Console.WriteLine("[{0}]: {1}", Sender.Path, message.ThingToWrite);
            });
        }

        public void QuietWriter()
        {
            Receive<WriteSomethingMessage>(msg =>
            {
                if (msg.ThingToWrite.ToLowerInvariant() == "be loud")
                {
                    Console.WriteLine("Letting it all out!");
                    Stash.UnstashAll();
                    Become(NormalWriter);
                }
                else
                {
                    Stash.Stash();
                }
            });
        }

        public IStash Stash { get; set; }
    }
}