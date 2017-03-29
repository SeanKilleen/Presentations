using System;
using System.Runtime.Serialization;
using Akka.Actor;

namespace Supervision
{
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