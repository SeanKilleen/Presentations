using System;
using System.Threading.Tasks;
using Akka.Configuration;

namespace BlankSlate
{
    using Akka.Actor;

    class Program
    {
        static async Task Main()
        {
            var config = ConfigurationFactory.ParseString(@"# NOTE: Could also do this as akka.actor.deployment{}
    akka
    {   
      actor
      {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
      }
      stdout-loglevel = INFO
      remote 
      {
          dot-netty.tcp 
          {
                transport-protocol = tcp
                port = 9001
                hostname = ""localhost""        
         }
      }
    }");
            var actorSystem = ActorSystem.Create("BlankSlate", config);

            Console.WriteLine("Sitting here doing my thing");

            await actorSystem.WhenTerminated;
        }
    }
}
