using System;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Shared.Actors;

namespace Supervision
{
    class Program
    {
        static async Task Main()
        {
            var system = ActorSystem.Create("supervisionSystem");

            var parentActor = system.ActorOf(Props.Create<ParentActor>(), "parentActor");

            // Note that we're not passing it around as a variable; we're creating a reference at a location
            system.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriter");

            var numberRange = Enumerable.Range(1, 100);
            foreach (var number in numberRange)
            {
                parentActor.Tell(new ProcessANumber(number));
            }

            await system.WhenTerminated;
        }
    }
}
