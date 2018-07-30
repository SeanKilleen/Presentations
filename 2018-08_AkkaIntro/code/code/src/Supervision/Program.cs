using System;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;
using Akka.Routing;
using Shared;
using Supervision.Actors;
using Supervision.Messages;

namespace Supervision
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("monkeysOnBed");
            var parentActor = system.ActorOf(Props.Create<MonkeyParent>(), "parentMonkey");

            while (true)
            {
                Console.ReadLine();
                parentActor.Tell(new BumpAMonkey());
            }
        }
    }
}
