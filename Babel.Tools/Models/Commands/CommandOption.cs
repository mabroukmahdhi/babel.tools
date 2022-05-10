//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************

using System.Collections.Generic;
using System.Linq;

namespace Babel.Tools.Models.Commands
{
    public class CommandOption
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; }

        public string PreferedValue => Values?.FirstOrDefault();
    }
}
