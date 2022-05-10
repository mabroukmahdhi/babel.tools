//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class CommandServiceException : Xeption
    {
        public CommandServiceException(Exception innerException)
            : base(message: "Command service error occurred, contact support.", innerException)
        { }
    }
}
