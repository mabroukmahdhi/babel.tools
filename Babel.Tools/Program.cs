//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Brokers.Assemplies;
using Babel.Tools.Brokers.Executers;
using Babel.Tools.Brokers.Loggings;
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Commands.Exceptions;
using Babel.Tools.Services.Foundations.Commands;
using System;
using System.IO;
using System.Text;

namespace Babel.Tools
{
    public class Program
    {
        internal static ILoggingBroker LoggingBroker = new LoggingBroker();
        static void Main(string[] args)
        {
            try
            {
                var assemblyBroker = new AssemblyBroker();
                string assemblyDir = assemblyBroker.GetAssemblyDirectory();

                if (args.Length == 0
                    || BabelCommand.IsHelpCommand(args[0]))
                {
                    LoggingBroker.Log(File.ReadAllText(Path.Combine(assemblyDir, "Texts\\About.txt")));
                    return;
                }

                var commandService = new CommandService(
                    LoggingBroker,
                    new ExecuterBroker(assemblyDir));

                commandService.Execute(args);
            }
            catch (CommandServiceException ex)
            {
                LoggingBroker.LogError(ex.GetMessage());
            }
            catch (Exception ex)
            {
                LoggingBroker.LogError(ex.Message);
            }
        }
    }
}
