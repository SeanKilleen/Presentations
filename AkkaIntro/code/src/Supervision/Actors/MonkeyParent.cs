using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Shared.Actors;
using Shared.Messages;
using Supervision.Messages;

namespace Supervision.Actors
{
    public class MonkeyParent : ReceiveActor
    {
        private readonly List<IActorRef> _childMonkeys;
        private readonly IActorRef _consoleWriter;
        public MonkeyParent()
        {
            var doctor = Context.ActorOf(Props.Create<MonkeyDoctor>());
            _consoleWriter = Context.ActorOf(Props.Create<ConsoleWriterActor>());

            var childMonkeyProps = Props.Create<MonkeyChild>();

            _childMonkeys = new List<IActorRef>
            {
                Context.ActorOf(childMonkeyProps, "cm1"),
                Context.ActorOf(childMonkeyProps, "cm2"),
                Context.ActorOf(childMonkeyProps, "cm3"),
                Context.ActorOf(childMonkeyProps, "cm4"),
                Context.ActorOf(childMonkeyProps, "cm5")
            };

            Receive<MonkeyCountUpdate>(msg =>
            {
                _consoleWriter.Tell(new WriteSomethingMessage($"{msg.NumberMonkeys} little monkeys jumping on the bed."));
                _childMonkeys.ForEach(x=>x.Tell(new Jump()));
            });

            Receive<AMonkeyGotBumped>(msg =>
            {
                _childMonkeys.Remove(msg.MonkeyThatGotBumped);
                Self.Tell(new MonkeyCountUpdate(_childMonkeys.Count));
            });

            Receive<CallTheDoctor>(message =>
            {
                doctor.Tell(new BumpedHeadMessage());
            });

            Receive<BumpAMonkey>(msg =>
            {
                if (!_childMonkeys.Any())
                {
                    _consoleWriter.Tell(new WriteSomethingMessage("NO MONKEYS LEFT! Bummer."));
                }
                else
                {
                    _childMonkeys.First().Tell(new BumpedHeadMessage());
                }
            });

            Self.Tell(new MonkeyCountUpdate(_childMonkeys.Count));
        }


        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(x =>
            {
                if (x is BumpedHeadException)
                {
                    _consoleWriter.Tell(new WriteSomethingMessage("I got a bumped head exception"));
                    var ex = x as BumpedHeadException;
                    Self.Tell(new AMonkeyGotBumped(ex.Monkey));
                    return Directive.Stop;
                }

                return Directive.Restart;
            });
        }
    }
}