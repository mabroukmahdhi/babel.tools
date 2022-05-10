//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Brokers.Executers;
using Babel.Tools.Brokers.Loggings;
using Babel.Tools.Models.Commands;
using System.Linq;

namespace Babel.Tools.Services.Foundations.Commands
{
    public partial class CommandService : ICommandService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IExecuterBroker executerBroker;
        public CommandService(
            ILoggingBroker loggingBroker,
            IExecuterBroker executerBroker)
        {
            this.loggingBroker = loggingBroker;
            this.executerBroker = executerBroker;
        }
        public IBabelCommand BuildCommand(object[] args)
            => TryCatch(() =>
            {
                ValidateCommadExists(args);

                string commandName = args[0] as string;

                IBabelCommand command = null;

                if (commandName.Equals(BabelCommand.DocumentationCommandName, System.StringComparison.OrdinalIgnoreCase))
                {
                    var arguments = args.Cast<string>().ToArray();
                    string[] options = arguments.Skip(2).ToArray();
                    command = new DocumentationCommand(arguments[1], options);
                    ValidateCommandAction(command, arguments[1]);
                    return command;
                }

                if (commandName.Equals(BabelCommand.ImportFilesCommandName, System.StringComparison.OrdinalIgnoreCase))
                {
                    var arguments = args.Cast<string>().ToArray();
                    string[] options = arguments.Skip(2).ToArray();
                    command = new ImportFilesCommand(arguments[1], options);
                    ValidateCommandAction(command, arguments[1]);
                    return command;
                }

                return command;
            });


        public void Execute(object[] args)
            => TryCatch(() =>
            {
                var command = BuildCommand(args);

                var outputs = this.executerBroker.Execute(command);

                this.loggingBroker.Log(outputs);
            });


    }
}
