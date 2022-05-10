//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class CommandValidationException : Xeption
    {
        public CommandValidationException(Xeption innerException)
            : base(message: "Command validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
