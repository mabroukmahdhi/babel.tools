//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.IO;
using System.Reflection;

namespace Babel.Tools.Brokers.Assemplies
{
    public class AssemblyBroker : IAssemblyBroker
    {
        public string GetAssemblyDirectory()
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
