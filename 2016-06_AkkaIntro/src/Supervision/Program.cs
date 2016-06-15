using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;
using Akka.Routing;
using Shared;

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
    public class MonkeyChild : ReceiveActor
    {
        private readonly IActorRef _consoleLogger;
        private readonly string _name;
        public MonkeyChild()
        {
            _name = Self.Path.Name;
            _consoleLogger = Context.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriterActor");

            _consoleLogger.Tell($"{_name} created!");

            Receive<BumpedHeadMessage>(message =>
            {
                BumpHead();
            });

            Receive<Jump>(msg =>
            {
                _consoleLogger.Tell(new WriteSomethingMessage("Jumping!"));
            });
        }
        private void BumpHead()
        {
            _consoleLogger.Tell(new WriteSomethingMessage("OW! Bumped my head!"));
            throw new BumpedHeadException(Self);
        }

    }
    public class MonkeyDoctor : ReceiveActor
    {
        public MonkeyDoctor()
        {
            var consoleWriter = Context.ActorOf(Props.Create<ConsoleWriterActor>());

            Receive<BumpedHeadMessage>(msg =>
            {
                consoleWriter.Tell(new WriteSomethingMessage("Doctor says: NO MORE MONKEYS JUMPING ON THE BED!"));
            });
        }
    }

    public class AMonkeyGotBumped
    {
        public IActorRef MonkeyThatGotBumped { get; }

        public AMonkeyGotBumped(IActorRef bumpedMonkey)
        {
            MonkeyThatGotBumped = bumpedMonkey;
        }
    }

    public class BumpAMonkey { }
    public class MonkeyCountUpdate
    {
        public int NumberMonkeys { get; }

        public MonkeyCountUpdate(int numMonkeys)
        {
            NumberMonkeys = numMonkeys;
        }
    }

    public class CallTheDoctor { }

    public class Jump { }
    public class BumpedHeadMessage { }

    [Serializable]
    public class BumpedHeadException : Exception
    {
        public IActorRef Monkey { get; }

        public BumpedHeadException(IActorRef monkey)
        {
            Monkey = monkey;
        }
        protected BumpedHeadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
