using Akka.Actor;
using Akka.Routing;

namespace Supervision
{
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
}