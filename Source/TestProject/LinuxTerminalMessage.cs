﻿using CrossPlattformUtils;
using NLog;

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
            logger.Debug("all works fine");

        }

        private readonly IOutputWriter output;
    }
}