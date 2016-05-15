using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Timers;
using Serilog;
using Topshelf;

namespace TopShelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<TownCrier>(s =>
                {
                    s.ConstructUsing(name => new TownCrier());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsPrompt();

                x.SetDescription("Sample Topshelf Host (TownCrier)");
                x.SetDisplayName("The Town Crier");
                x.SetServiceName("TownCrier");
            });
        }
    }

    public class TownCrier
    {
        readonly Timer _timer;
        readonly ILogger _logger;

        public TownCrier()
        {
            _logger = new LoggerConfiguration().WriteTo.File("TheService.log").CreateLogger();
            _timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);

            _timer.Elapsed += (sender, eventArgs) => _logger.Information("It is {theCurrentTime} and all is well!", DateTime.Now);
        }

        public void Start() { _timer.Start();}

        public void Stop() {  _timer.Stop();}
    }
}
