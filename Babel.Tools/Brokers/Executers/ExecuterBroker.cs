//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Outputs;
using System;
using System.IO;
using System.Reflection;

namespace Babel.Tools.Brokers.Executers
{
    public partial class ExecuterBroker : IExecuterBroker
    {
        private const string documentationCommandName = "docu";

        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public OutputCollection Execute(IBabelCommand command)
        {
            if (command.Name.Equals(documentationCommandName))
            {
                return ExecuteDocumentationCommand(command as DocumentationCommand);
            }

            return ReturnNoCommandCanBeRun();
        }

        private OutputCollection ReturnNoCommandCanBeRun()
            => new()
            {
                new OutputMessage()
                {
                    Message = "There is no Babel Command to run.",
                    OutputType = OutputType.Error
                }
            };

        private OutputCollection ReturnAboutFile(string file)
        {
            var outputs = new OutputCollection(linePrefix: "");
            var lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                outputs.Log(line);
            }

            return outputs;
        }


    }
}
