using CrossPlattformUtils;
using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Injector.Add<IOutputWriter, ConsoleOutput>();

            var messageImpl = Allocator.New<ITerminalMessage>();

            Console.WriteLine(messageImpl.Message);
            Console.ReadLine();
        }
    }
}
