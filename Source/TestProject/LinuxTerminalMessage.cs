using CrossPlattformUtils;

namespace TestProject
{
    [PlattformImplementation(Platform.Linux)]
    public class LinuxTerminalMessage : ITerminalMessage
    {
        private readonly IOutputWriter output;

        public LinuxTerminalMessage(IOutputWriter output)
        {
            this.output = output;

            output.Write("Hello from Linux");
        }
        public string Message => "im on linux";
    }
}