using System.Threading.Tasks;

namespace Routing
{
    using System;
    using Akka.Actor;

    class Program
    {
        static async Task Main()
        {
            var actorSystem = ActorSystem.Create("ElasticSystem");

            var demoActor = actorSystem.ActorOf(Props.Create<DemoActor>(), "demoActor");

            demoActor.Tell(new StartDemo());

            await actorSystem.WhenTerminated;
        }
    }
}
