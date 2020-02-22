namespace TestProject
{
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            System.Console.WriteLine("[Dbg] " + msg);
        }
    }
}