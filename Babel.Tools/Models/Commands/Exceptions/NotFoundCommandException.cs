//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class NotFoundCommandException : Xeption
    {
        public NotFoundCommandException(string commandName, string option = "")
            : base(message: $"Couldn't find command with name: {commandName}" +
                            $"{(string.IsNullOrWhiteSpace(option) ? "" : $" and action/option: {option}")}.")
        { }

        public NotFoundCommandException(string commandName)
            : this(commandName, string.Empty)
        { }
    }
}
