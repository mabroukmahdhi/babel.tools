//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class CommandDependencyException : Xeption
    {
        public CommandDependencyException(Exception innerException) :
              base(message: "Command dependency error occurred, contact support.", innerException)
        { }
    }
}
