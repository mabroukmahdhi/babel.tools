//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System.Collections.Generic;

namespace Babel.Tools.Models.Commands
{
    public class DocumentationCommand : BabelCommand
    {
        public const string OptionReplace = "-r|--replace-chars";
        public const string OptionReplaceName = "replace";
        public DocumentationCommand(string name, IEnumerable<CommandOption> options)
            : base(name, options)
        { }

        public override string Name => "docu";

        protected override IEnumerable<CommandOption> DefaultOptions
            => new List<CommandOption>()
            {
                new CommandOption()
                {
                    Name = OptionReplaceName,
                    Values =OptionReplace.Split('|')
                }
            };
    }
}
