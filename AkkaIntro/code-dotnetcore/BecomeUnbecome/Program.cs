using System;
using Akka.Actor;
using Shared.Actors;
using Shared.Messages;

namespace BecomeUnbecome
{
    class Program
    {
        static void Main()
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
