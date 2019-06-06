using Akka.Actor;
using Shared.Actors;
using Shared.Messages;
using Supervision.Messages;

namespace Supervision.Actors
{
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
}