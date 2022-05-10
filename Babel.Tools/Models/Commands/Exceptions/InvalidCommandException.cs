//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class InvalidCommandException : Xeption
    {
        public InvalidCommandException()
            : base(message: "Invalid command. Please correct the errors and try again.")
        { }
    }
}
