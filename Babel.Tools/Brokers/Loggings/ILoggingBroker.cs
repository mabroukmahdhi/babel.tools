//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Tools.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
