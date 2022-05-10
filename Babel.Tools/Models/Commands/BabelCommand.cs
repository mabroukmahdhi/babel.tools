//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.Collections.Generic;
using System.Linq;

namespace Babel.Tools.Models.Commands
{
    public abstract class BabelCommand
    {
        public BabelCommand(IEnumerable<CommandOption> options)
        {
            Options = options;
        }
        public abstract string Name { get; }

        public IEnumerable<CommandOption> Options { get; set; }

        protected abstract IEnumerable<CommandOption> DefaultOptions { get; }

        public bool HasOptions => Options?.Any() ?? false;
    }
}
