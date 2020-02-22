using CrossPlattform;

namespace TestProject
{
    [PlattformImplementation(Platform.Linux)]
    public class LinuxTerminalMessage : ITerminalMessage
    {
        private readonly IOutputWriter output;

        public LinuxTerminalMessage(IOutputWriter output, ILogger logger)
        {
            this.output = output;

            output.Write("Hello from Linux");
            logger.Log("all works fine");
        }
        public string Message => "im on linux";
    }
}