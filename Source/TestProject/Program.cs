using CrossPlattformUtils;
using System;

namespace TestProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Injector.Add<IOutputWriter, ConsoleOutput>();

            var messageImpl = Instance.New<ITerminalMessage>();

            Console.WriteLine(messageImpl.Message);
            Console.ReadLine();
        }
    }
}