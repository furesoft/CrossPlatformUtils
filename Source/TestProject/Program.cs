using CrossPlattformUtils;
using NLog;
using System;

namespace TestProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);

            // Apply config
            LogManager.Configuration = config;

            //Injector.Add<IOutputWriter, ConsoleOutput>();
            Injector.Add<ILogger>(LogManager.GetCurrentClassLogger());
            Injector.AutoCollect();

            // select automatic instance based on operating system
            var messageImpl = Instance.New<ITerminalMessage>();

            Console.WriteLine(messageImpl.Message);
            Console.ReadLine();
        }
    }
}