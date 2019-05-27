namespace Routing
{
    using System;
    using Akka.Actor;

    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("ElasticSystem");

            var demoActor = actorSystem.ActorOf(Props.Create<DemoActor>(), "demoActor");

            demoActor.Tell(new StartDemo());

            Console.ReadLine();
        }
    }
}
