//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.Collections.ObjectModel;

namespace Babel.Tools.Models.Outputs
{
    public class OutputCollection : Collection<OutputMessage>
    {
        public OutputCollection(string linePrefix = "BT > ")
        {
            this.LinePrefix = linePrefix;
        }
        public string LinePrefix { get; set; }
        protected void Add(string message, OutputType type)
            => Add(new OutputMessage()
            {
                Message = $"{LinePrefix} {message}",
                OutputType = type
            });

        public void Log(string message)
            => Add(message, OutputType.Log);

        public void Info(string message)
            => Add(message, OutputType.Info);

        public void Error(string message)
            => Add(message, OutputType.Error);

        public void Warn(string message)
            => Add(message, OutputType.Warning);

    }
    public class OutputMessage
    {
        public string Message { get; set; }
        public OutputType OutputType { get; set; }
    }

    public enum OutputType
    {
        Info,
        Log,
        Warning,
        Error
    }

}
