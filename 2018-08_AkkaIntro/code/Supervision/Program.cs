using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;
using Shared.Actors;
using Shared.Messages;

namespace Supervision
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("supervisionSystem");

            var parentActor = system.ActorOf(Props.Create<ParentActor>(), "parentActor");
            var consoleWriter = system.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriter");

            var numberRange = Enumerable.Range(1, 100);
            foreach (var number in numberRange)
            {
                consoleWriter.Tell(new WriteSomethingMessage($"Submitting number {number} for processing"));
                parentActor.Tell(new ProcessANumber(number));
            }

            Console.ReadLine();
        }
    }

    public class ParentActor : ReceiveActor
    {
        private readonly IActorRef _volatileChildren;

        public ParentActor()
        {
            var props = Props.Create<VolatileChildActor>()
                .WithRouter(new RoundRobinPool(3));

            _volatileChildren = Context.ActorOf(props);

            Receive<ProcessANumber>(msg =>
            {
                _volatileChildren.Tell(msg);
            });
        }
        //protected override SupervisorStrategy SupervisorStrategy()
        //{
        //    return new OneForOneStrategy(
        //        maxNrOfRetries:10, 
        //        withinTimeMilliseconds:1000, 
        //        localOnlyDecider: ex => Directive.Resume);
        //}

    }

    public class VolatileChildActor : ReceiveActor
    {
        private readonly IActorRef _consoleWriter;
        private int processedNumbers = 0;
        public VolatileChildActor()
        {
            _consoleWriter = Context.ActorOf<ConsoleWriterActor>("consoleWriter");

            Receive<ProcessANumber>(msg =>
            {
                if (processedNumbers == 6)
                {
                    processedNumbers = 0;
                    throw new Exception($"I already processed 6 numbers; too tried to process number {msg.Number}");
                }

                _consoleWriter.Tell(new WriteSomethingMessage($"Processing number: {msg.Number}"), Self);
                processedNumbers++;
            });
        }
    }

    public class ProcessANumber
    {
        public int Number { get; }

        public ProcessANumber(int number)
        {
            Number = number;
        }
    }
}
