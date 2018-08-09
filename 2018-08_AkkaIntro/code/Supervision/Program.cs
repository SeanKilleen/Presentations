using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;

namespace Supervision
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("supervisionSystem");

            var parentActor = system.ActorOf(Props.Create<ParentActor>());

            var numberRange = Enumerable.Range(1, 100);
            foreach(var number in numberRange)
            {
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
    }

    public class VolatileChildActor : ReceiveActor
    {
        public VolatileChildActor()
        {
            Receive<ProcessANumber>(msg =>
            {
                Console.WriteLine(msg.Number);
            });
        }
    }

    public class StartDemoMessage { }

    public class ProcessANumber
    {
        public int Number { get; }

        public ProcessANumber(int number)
        {
            Number = number;
        }
    }
}
