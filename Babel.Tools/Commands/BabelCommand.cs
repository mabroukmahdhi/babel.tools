//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Tools.Commands
{
    internal abstract class BabelCommand
    {
        public BabelCommand(string name, IEnumerable<CommandOption> options)
        {
            Name = name;
            Options = options;
        }
        public string Name { get; set; }

        public IEnumerable<CommandOption> Options { get; set; }

        public bool HasOptions => Options?.Any() ?? false;

        public abstract void Validate(object[] args);
        public virtual void Execute(object[] args)
        {
            Validate(args);
        }
    }
}
