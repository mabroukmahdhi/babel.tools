//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.Collections.Generic;

namespace Babel.Tools.Models.Commands
{
    public class CommandAction
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
        public List<string> Options { get; set; }
    }
}
