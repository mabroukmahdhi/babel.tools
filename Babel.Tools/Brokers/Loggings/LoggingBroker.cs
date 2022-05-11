//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Outputs;
using System;

namespace Babel.Tools.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }


        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }


        public void LogWarining(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Log(OutputMessage message)
        {
            switch (message.OutputType)
            {
                case OutputType.Info:
                    LogInfo(message.Message);
                    break;
                case OutputType.Warning:
                    LogWarining(message.Message);
                    break;
                case OutputType.Error:
                    LogError(message.Message);
                    break;
                case OutputType.Log:
                default:
                    Log(message.Message);
                    break;
            }
        }

        public void Log(OutputCollection outputs)
        {
            foreach (var output in outputs)
            {
                Log(output);
            }
        }
    }
}
