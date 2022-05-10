//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Tools.Brokers.Assemplies
{
    public class AssemblyBroker : IAssemblyBroker
    {
        public string GetAssemblyDirectory()
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
