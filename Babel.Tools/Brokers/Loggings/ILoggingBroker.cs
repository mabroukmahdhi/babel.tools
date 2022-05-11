//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

using Babel.Tools.Models.Outputs;

namespace Babel.Tools.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void Log(OutputMessage message);
        void Log(OutputCollection outputs);
        void Log(string message);
        void LogInfo(string message);
        void LogWarining(string message);
        void LogError(string message);
    }
}
