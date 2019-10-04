using System;
using System.Threading.Tasks;

namespace BlankSlate
{
    using Akka.Actor;

    class Program
    {
        static async Task Main()
        {
            var actorSystem = ActorSystem.Create("BlankSlate");

            Console.WriteLine("Sitting here doing my thing");

            await actorSystem.WhenTerminated;
        }
    }
}
