using System;
using System.Threading;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class RandomNumberAfterRandomTimeWorker : ReceiveActor
    {
        private readonly IActorRef _consoleWriterActorRef;

        public RandomNumberAfterRandomTimeWorker()
        {
            _consoleWriterActorRef = Context.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriter");

            Receive<GenerateRandomNumberMessage>(msg =>
            {
                _consoleWriterActorRef.Tell(new WriteSomethingMessage("I've been told to generate a number"));
                var numberGenerator = new Random();

                var secsToWait = numberGenerator.Next(1, 10);
           
                Thread.Sleep(TimeSpan.FromSeconds(secsToWait));

                var randomNumber = numberGenerator.Next(1, 1000000000);

                var thingToWrite = string.Format("Generated Random number '{0}' after {1} seconds", randomNumber, secsToWait);
                _consoleWriterActorRef.Tell(new WriteSomethingMessage(thingToWrite));

            });
        }
    }

}