using Akka.Actor;

namespace Supervision.Messages
{
    public class AMonkeyGotBumped
    {
        public IActorRef MonkeyThatGotBumped { get; }

        public AMonkeyGotBumped(IActorRef bumpedMonkey)
        {
            MonkeyThatGotBumped = bumpedMonkey;
        }
    }
}