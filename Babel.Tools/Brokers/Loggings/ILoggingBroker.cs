//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

namespace Babel.Tools.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
