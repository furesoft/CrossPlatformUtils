namespace TestProject
{
    [PlattformImplementation(Platform.Linux)]
    public class LinuxTerminalMessage : ITerminalMessage
    {
        public string Message => "im on linux";

        public LinuxTerminalMessage(IOutputWriter output, ILogger logger)
        {
            this.output = output;

            output.Write("Hello from Linux");
            logger.Log("all works fine");
        }

        private readonly IOutputWriter output;
    }
}