using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Shared.Actors;
using Shared.Messages;

namespace BecomeUnbecome
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("becomeUnbecomeDemo");
            var variableWriter = actorSystem.ActorOf<VariableConsoleWriterActor>();

            Console.WriteLine("Say some things!");
            while (true)
            {
                var text = Console.ReadLine();
                variableWriter.Tell(new WriteSomethingMessage(text), ActorRefs.Nobody);
            }
        }
    }
}
