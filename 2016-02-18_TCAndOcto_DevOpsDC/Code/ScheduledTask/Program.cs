using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ScheduledTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.File("theLog.log")
                .CreateLogger();

            var myObj = new MyLogObject() {TheNumber = 42, TheString = "Hello World", TheDateTime = DateTime.Now};

            logger.Information("The myObject is: {@theStuff}", myObj);
        }
    }

    class MyLogObject
    {
        public int TheNumber { get; set; }
        public string TheString { get; set; }
        public DateTime TheDateTime { get; set; }
    }
}
