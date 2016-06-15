using System;
using System.Collections.Generic;

using Akka.Actor;

namespace Supervision
{
    #region BossActor messages

    public class AddMinionMessage
    {
    }

    public class CrackTheWhipMessage
    {
    }

    public class RefreshMinionsMessage
    {
    }

    public class GibberishMessage
    {
        public string ID { get; private set; }
        public GibberishMessage()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }

    #endregion

    public class BossActor : ReceiveActor
    {
        public static Props Props(Action<IActorRef> minionAdded)
        {
            return Akka.Actor.Props.Create(() => new BossActor(minionAdded));
        }

        Queue<string> names = new Queue<string>();

        Action<IActorRef> minionAdded;

        public BossActor(Action<IActorRef> minionAdded)
        {
            this.minionAdded = minionAdded;

            names.Enqueue("Kevin");
            names.Enqueue("Stuart");
            names.Enqueue("Bob");
            names.Enqueue("Dave");
            names.Enqueue("Jerry");
            names.Enqueue("Donny");
            names.Enqueue("Norbert");
            names.Enqueue("Carl");
            names.Enqueue("Tim");
            names.Enqueue("Steve");

            Receive<AddMinionMessage>(x => AddMinion(x));

            Receive<CrackTheWhipMessage>(x => {
                foreach (var item in Context.GetChildren())
                {
                    item.Tell(new GibberishMessage());
                }
            });

            Receive<RefreshMinionsMessage>(x => {
                foreach (var item in Context.GetChildren())
                {
                    minionAdded(item);
                }
            });
        }

        private void AddMinion(AddMinionMessage msg)
        {
            string name = names.Count == 0 ? Guid.NewGuid().ToString() : names.Dequeue();
            minionAdded(Context.ActorOf<MinionActor>(name));
        }
    }
}
