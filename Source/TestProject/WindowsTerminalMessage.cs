using CrossPlattform;

namespace TestProject
{
    [PlattformImplementation(Platform.Windows)]
    public class WindowsTerminalMessage : ITerminalMessage
    {
        private readonly IOutputWriter output;

        public WindowsTerminalMessage(IOutputWriter output, ILogger logger)
        {
            this.output = output;
            output.Write("Hello from Windows");
            logger.Log("all works fine");
        }

        public string Message => "im on windows";
    }
}
