//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Text;
using Xeptions;

namespace Babel.Tools.Models.Commands.Exceptions
{
    public class CommandServiceException : Xeption
    {
        public CommandServiceException(Exception innerException)
            : base(message: "Command service error occurred, contact support.", innerException)
        { }

        public string GetMessage()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(Message);
            Exception exception = this;
            while (exception.InnerException != null)
            {
                stringBuilder.AppendLine($"\t=> {exception.InnerException.Message}");
                exception = exception.InnerException;
            }
            return stringBuilder.ToString();
        }
    }
}
