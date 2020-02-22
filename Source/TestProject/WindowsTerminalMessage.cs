namespace TestProject
{
    [PlattformImplementation(Platform.Windows)]
    public class WindowsTerminalMessage : ITerminalMessage
    {
        public string Message => "im on windows";

        public WindowsTerminalMessage(IOutputWriter output, ILogger logger)
        {
            this.output = output;
            output.Write("Hello from Windows");
            logger.Log("all works fine");
        }

        private readonly IOutputWriter output;
    }
}