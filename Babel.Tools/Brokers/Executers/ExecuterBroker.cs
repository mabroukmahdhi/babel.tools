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

        private readonly string assemlyLocation;
        public ExecuterBroker(string assemlyLocation)
            => this.assemlyLocation = assemlyLocation;

        public OutputCollection Execute(IBabelCommand command)
        {
            if (command.Name.Equals(BabelCommand.DocumentationCommandName))
            {
                return ExecuteDocumentationCommand(command as DocumentationCommand);
            }

            if (command.Name.Equals(BabelCommand.ImportFilesCommandName))
            {
                return ExecuteImportFilesCommand(command as ImportFilesCommand);
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
            outputs.Log(File.ReadAllText(file));
            return outputs;
        }


    }
}
