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
                enforce-ip-family = true
                dns-use-ipv6 = false
                transport-protocol = tcp
                port = 9001
                public-hostname = ""localhost""
                hostname = ""127.0.0.1""        
         }
      }
    }");
            var actorSystem = ActorSystem.Create("BlankSlate", config);

            Console.WriteLine("Sitting here doing my thing");

            await actorSystem.WhenTerminated;
        }
    }
}
