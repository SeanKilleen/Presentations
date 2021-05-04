using Akka.Actor;

namespace Supervision
{
    public class ParentActor : ReceiveActor
    {
        private readonly IActorRef _volatileChildren;

        public ParentActor()
        {
            var props = Props.Create<VolatileChildActor>();

            _volatileChildren = Context.ActorOf(props, "children");

            Receive<ProcessANumber>(msg =>
            {
                _volatileChildren.Tell(msg);
            });
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                localOnlyDecider: ex => Directive.Stop);
        }
    }
}