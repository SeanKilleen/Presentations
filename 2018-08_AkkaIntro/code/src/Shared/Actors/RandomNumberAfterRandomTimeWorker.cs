using System;
using System.Threading.Tasks;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class RandomNumberAfterRandomTimeWorker : ReceiveActor
    {
        private readonly IActorRef _consoleWriterActorRef;

        public RandomNumberAfterRandomTimeWorker()
        {
            _consoleWriterActorRef = Context.ActorOf(Props.Create<ConsoleWriterActor>());
            Console.WriteLine("console actor created at {0}", _consoleWriterActorRef.Path);

            Receive<GenerateRandomNumberMessage>(async msg =>
            {
                var numberGenerator = new Random();

                var secsToWait = numberGenerator.Next(1, 10);
                await Task.Delay(TimeSpan.FromSeconds(secsToWait));

                var randomNumber = numberGenerator.Next(1, 1000000000);

                var thingToWrite = string.Format("Generated Random number '{0}' after {1} seconds", randomNumber, secsToWait);
                _consoleWriterActorRef.Tell(new WriteSomethingMessage(thingToWrite));

            });
        }
    }

}