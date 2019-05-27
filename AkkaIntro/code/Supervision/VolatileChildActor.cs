using System;
using Akka.Actor;
using Shared.Messages;

namespace Supervision
{
    public class VolatileChildActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly ActorSelection _consoleWriter;
        private int processedNumbers = 0;
        public VolatileChildActor()
        {
            _consoleWriter = Context.ActorSelection("/user/consoleWriter");


            Receive<ProcessANumber>(msg =>
            {
                if (processedNumbers == 6)
                {
                    processedNumbers = 0;
                    throw new Exception($"I already processed 6 numbers; too tired to process number {msg.Number}");
                }

                _consoleWriter.Tell(new WriteSomethingMessage($"Processing number: {msg.Number}"), Self);
                processedNumbers++;
            });
        }

        //protected override void PreRestart(Exception reason, object message)
        //{
        //    Stash.Stash();
        //}

        //protected override void PostRestart(Exception reason)
        //{
        //    Stash.UnstashAll();
        //}

        public IStash Stash { get; set; }
    }
}