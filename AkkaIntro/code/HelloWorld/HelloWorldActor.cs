using Akka.Actor;
using Shared.Actors;
using Shared.Messages;

namespace HelloWorld
{
    public class HelloWorldActor : ReceiveActor
    {
        private readonly IActorRef _consoleWriter;

        public HelloWorldActor()
        {
            _consoleWriter = Context.ActorOf<ConsoleWriterActor>();

            Receive<HelloWorldMessage>(message =>
            {
                _consoleWriter.Tell(new WriteSomethingMessage($"Hello, {message.Name}"), Self);
            });

            Receive<FinishedMessage>(message =>
            {
                _consoleWriter.Tell(new WriteSomethingMessage("I guess we're done here!"));
            });
        }
    }
}