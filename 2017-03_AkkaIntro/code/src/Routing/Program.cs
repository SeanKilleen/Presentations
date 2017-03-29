using System.Security.Cryptography;

namespace Routing
{
    using System;
    using System.Threading.Tasks;

    using Akka.Actor;
    using Akka.Routing;

    using Shared;

    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync()).Wait();
        }

        static async Task MainAsync()
        {
            var actorSystem = ActorSystem.Create("ElasticSystem");

            Props props; // Just doing it like this for demo purposes

            // Example 1: Single actor
            props = Props.Create<RandomNumberAfterRandomTimeWorker>();

            // Example 2: Router from code
            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(new RoundRobinPool(1));
            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(new RoundRobinPool(5));

            // Example 3: Router from configuration
            //props = Props.Create<RandomNumberAfterRandomTimeWorker>().WithRouter(FromConfig.Instance);

            var randomNumberActor = actorSystem.ActorOf(props, "workers");

            Console.WriteLine("randomNumberActor at {0}", randomNumberActor.Path);
            var consoleWriter = actorSystem.ActorOf(Props.Create<ConsoleWriterActor>());

            while (true) // Infinitely looping to constantly queue up messages.
            {
                consoleWriter.Tell(new WriteSomethingMessage("Telling the workers to generate a number"));
                await Task.Delay(TimeSpan.FromSeconds(1));
                randomNumberActor.Tell(new GenerateRandomNumberMessage());
            }

        }

    }
}
