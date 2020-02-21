using CrossPlattformUtils;

namespace TestProject
{
    [PlattformImplementation(Platform.Windows)]
    public class WindowsTerminalMessage : ITerminalMessage
    {
        private readonly IOutputWriter output;

        public WindowsTerminalMessage(IOutputWriter output)
        {
            this.output = output;
            output.Write("Hello from Windows");
        }

        public string Message => "im on windows";
    }
}
