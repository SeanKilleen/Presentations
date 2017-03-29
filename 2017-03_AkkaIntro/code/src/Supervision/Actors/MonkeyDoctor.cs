using Akka.Actor;
using Shared.Actors;
using Shared.Messages;

namespace Supervision
{
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
}