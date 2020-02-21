using System;

namespace TestProject
{
    public class ConsoleOutput : IOutputWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}