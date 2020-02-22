using CrossPlattformUtils;
using NLog;
using System.Collections.Generic;

namespace TestProject
{
    [PlattformImplementation(Platform.Windows)]
    public class WindowsTerminalMessage : ITerminalMessage
    {
        public string Message => "im on windows";

        public WindowsTerminalMessage(IOutputWriter output, ILogger logger, IEnumerable<int> values)
        {
            this.output = output;
            output.Write("Hello from Windows");
            logger.Debug("all works fine");

            foreach (var v in values)
            {
                logger.Info(v);
            }
        }

        private readonly IOutputWriter output;
    }
}