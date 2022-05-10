//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.Collections.Generic;

namespace Babel.Tools.Models.Commands
{
    public interface IBabelCommand
    {
        string Name { get; }

        IEnumerable<CommandAction> Actions { get; }

        bool HasOption(string option);
        bool HasAction(string action);
    }
}
