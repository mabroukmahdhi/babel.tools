//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Brokers.Executers;
using Babel.Tools.Brokers.Loggings;
using Babel.Tools.Models.Commands;
using Babel.Tools.Services.Foundations.Commands;
using System;
using System.IO;

namespace Babel.Tools
{
    public class Program
    {
        internal static ILoggingBroker LoggingBroker = new LoggingBroker();
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0
                    || BabelCommand.IsHelpCommand(args[0]))
                {
                    LoggingBroker.Log(File.ReadAllText(".\\Texts\\About.txt"));
                    return;
                }

                var commandService = new CommandService(LoggingBroker, new ExecuterBroker());

                commandService.Execute(args);
            }
            catch (Exception ex)
            {
                LoggingBroker.LogError(ex.ToString());
            }
        }
    }
}
