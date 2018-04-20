using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankSlate
{
    using Akka.Actor;

    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync(args)).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var actorSystem = ActorSystem.Create("BlankSlate");

            Console.WriteLine("Sitting here doing my thing");
            Console.ReadLine();
        }
    }
}
