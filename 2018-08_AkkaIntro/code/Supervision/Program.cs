﻿using System;
using System.Linq;
using Akka.Actor;
using Akka.Routing;
using DotNetty.Handlers.Timeout;
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
            var routerSupervisionStrategy = new OneForOneStrategy(
                localOnlyDecider: ex => Directive.Resume);

            var props = Props.Create<VolatileChildActor>()
                .WithRouter(new RoundRobinPool(1)
                    .WithSupervisorStrategy(routerSupervisionStrategy)
                );

            _volatileChildren = Context.ActorOf(props, "children");

            Receive<ProcessANumber>(msg =>
            {
                _volatileChildren.Tell(msg);
            });
        }
    }

    public class VolatileChildActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly ActorSelection _consoleWriter;
        private int processedNumbers = 0;
        public VolatileChildActor()
        {
            _consoleWriter = Context.ActorSelection("/user/consoleWriter");


            Receive<ProcessANumber>(msg =>
            {
                if (processedNumbers == 6)
                {
                    processedNumbers = 0;
                    throw new Exception($"I already processed 6 numbers; too tired to process number {msg.Number}");
                }

                _consoleWriter.Tell(new WriteSomethingMessage($"Processing number: {msg.Number}"), Self);
                processedNumbers++;
            });
        }

        //protected override void PreRestart(Exception reason, object message)
        //{
        //    Stash.Stash();
        //}

        //protected override void PostRestart(Exception reason)
        //{
        //    Stash.UnstashAll();
        //}

        public IStash Stash { get; set; }
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
