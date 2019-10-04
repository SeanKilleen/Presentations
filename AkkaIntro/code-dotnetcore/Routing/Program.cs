﻿using System.Threading.Tasks;
using Akka.Configuration;

namespace Routing
{
    using System;
    using Akka.Actor;

    class Program
    {
        static async Task Main()
        {
            var config = ConfigurationFactory.ParseString(@"akka.actor.deployment {
      # Uncomment these to add config for workers            
          /demoactor/workers {
            router = round-robin-pool
            nr-of-instances = 25
            remote = ""akka.tcp://BlankSlate@localhost:9001/""
          }
    }
    akka
    { 
        log-config-on-start = on
        stdout-loglevel = INFO

        actor 
        {
          provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
        }
      
        remote 
        {
            dot-netty.tcp 
            {
                  transport-protocol = tcp
                  port = 8091
                  hostname = ""localhost""        
            }
        }
    }
");

            var actorSystem = ActorSystem.Create("ElasticSystem", config);

            var demoActor = actorSystem.ActorOf(Props.Create<DemoActor>(), "demoactor");

            demoActor.Tell(new StartDemo());

            await actorSystem.WhenTerminated;
        }
    }
}
