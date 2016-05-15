using System;
using Akka.Actor;

namespace Supervision
{
    public class UiUpdateActor : ReceiveActor
    {
        public static Props Props(Action<Tuple<string, int, string>> update)
        {
            return Akka.Actor.Props.Create(() => new UiUpdateActor(update));
        }

        Action<Tuple<string, int, string>> update;

        public UiUpdateActor(Action<Tuple<string, int, string>> update)
        {
            this.update = update;

            //Receive<string>(x => update(x));

            Receive<UpdateRequestReplyMessage>(x => update(new Tuple<string, int, string>(x.Contents, x.Count, x.LastMessageId)));
        }
    }
}
