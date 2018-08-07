using Shared.Actors;
using Shared.Messages;

namespace Routing
{
    using System;
    using Akka.Actor;

    class Program
    {
        static void Main(string[] args)
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

            actorSystem.Scheduler.ScheduleTellRepeatedly(TimeSpan.Zero, TimeSpan.FromSeconds(1), randomNumberActor, new GenerateRandomNumberMessage(),ActorRefs.NoSender);

            Console.ReadLine();
        }
    }
}
