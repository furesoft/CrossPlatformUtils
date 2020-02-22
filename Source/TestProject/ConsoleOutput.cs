using CrossPlattformUtils;
using System;

namespace TestProject
{
    [Injectible(typeof(IOutputWriter))]
    public class ConsoleOutput : IOutputWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}