//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class FailedCommandServiceException : Xeption
    {
        public FailedCommandServiceException(Exception innerException)
            : base(message: "Failed command service occurred, please contact support", innerException)
        { }
    }
}
