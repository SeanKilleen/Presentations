using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using Microsoft.Extensions.Configuration;
using Shared.Actors;
using Shared.Messages;

namespace Routing
{
    public class DemoActor : ReceiveActor
    {
        private readonly IActorRef _randomNumberActor;
        private readonly IActorRef _consoleWriterActor;

        public DemoActor()
        {
            Props props; // Just doing it like this for demo purposes

            // Example 1: Single actor
            props = Props.Create<RandomNumberAfterRandomTimeWorker>();

            // Example 2: Router from code
            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(new RoundRobinPool(1));
            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(new RoundRobinPool(5));

            // Example 3: Router from configuration

            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(FromConfig.Instance);

            _randomNumberActor = Context.ActorOf(props, "workers");
            _consoleWriterActor = Context.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriter");
            

            Console.WriteLine($"demo actor started at {Self.Path}");
            Console.WriteLine($"randomNumberActor at {_randomNumberActor.Path}", _randomNumberActor.Path);

            Receive<StartDemo>(msg =>
            {
                _consoleWriterActor.Tell(new WriteSomethingMessage("Starting demo"));

                Context.System.Scheduler.ScheduleTellRepeatedly(
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(1),
                    _randomNumberActor,
                    new GenerateRandomNumberMessage(),
                    Self);
            });
        }
    }
}