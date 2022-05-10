//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Commands.Exceptions;
using Microsoft.Toolkit.Diagnostics;

namespace Babel.Tools.Services.Foundations.Commands
{
    public partial class CommandService
    {

        private void Validate(IBabelCommand command)
        {

        }

        private void ValidateCommadExists(object[] args)
        {
            Guard.IsNotNull(args, nameof(args));
            Guard.IsNotEmpty(args, nameof(args));

            Guard.IsAssignableToType<string>(args[0], "command");
            Guard.IsNotNullOrWhiteSpace(args[0] as string, "command");

            string cmd = args[0] as string;

            if (!BabelCommand.Commands.Contains(cmd.ToLower()))
            {
                throw new NotFoundCommandException(cmd);
            }

        }


        private void ValidateCommandAction(IBabelCommand command, string action)
        {
            Guard.IsNotNullOrWhiteSpace(action, nameof(action));

            if (!command.HasAction(action))
            {
                throw new NotFoundCommandException(command.Name, action);
            }
        }

    }
}
