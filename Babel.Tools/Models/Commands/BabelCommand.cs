//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Babel.Tools.Models.Commands
{
    public abstract class BabelCommand : IBabelCommand
    {
        public const string HelpCommands = "-h|--help";
        public static List<string> Commands => new()
        {
            "docu",
        };

        public static bool IsHelpCommand(string cmd)
            => HelpCommands.Split('|')
                           .Any(x => x.Equals(cmd, StringComparison.OrdinalIgnoreCase));

        public BabelCommand(string runAction, IEnumerable<string> runOptions)
        {
            RunAction = runAction;
            RunOptions = runOptions;
        }

        protected virtual IEnumerable<string> RunOptions { get; set; }
        public abstract string Name { get; }
        public virtual string RunAction { get; }

        public abstract IEnumerable<CommandAction> Actions { get; }

        public bool HasActions => Actions?.Any() ?? false;

        public virtual bool IsHelpAction => IsHelpCommand(RunAction);

        public virtual bool HasOption(string option)
            => Actions?.Any(o => o.Options.Contains(option)) ?? false;

        public virtual bool HasAction(string action)
           => Actions?.Any(a => a.Values.Contains(action)) ?? false;

        public virtual bool HasRunOptions => RunOptions?.Any() ?? false;
        protected abstract List<CommandAction> GenerateActions();
    }
}
