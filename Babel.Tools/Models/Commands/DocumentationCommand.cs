//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Babel.Tools.Models.Commands
{
    public class DocumentationCommand : BabelCommand
    {
        private const string ActionReplace = "replace";
        private const string ActionReplaceValues = "-r|--replace-chars";
        private const string ActionReplaceOptions = $"{ActionReplaceIgnoreOption}";
        private const string ActionReplaceIgnoreOption = "-i";

        public DocumentationCommand(string runAction, params string[] runOptions)
            : base(runAction, runOptions)
        { }

        public override string Name => DocumentationCommandName;

        public override IEnumerable<CommandAction> Actions
            => GenerateActions();

        public bool IsReplaceAction
            => ActionReplaceValues.Split('|')
                            .Any(o => o.Equals(RunAction, StringComparison.OrdinalIgnoreCase));

        public bool HasOptionIgnore
            => RunOptions?.Any(i => i.Equals(ActionReplaceIgnoreOption, StringComparison.OrdinalIgnoreCase)) ?? false;
        protected override List<CommandAction> GenerateActions()
            => new()
            {
                GenerateHelpAction(),
                GenerateReplaceAction()
            };

        private CommandAction GenerateReplaceAction()
        {
            var aValues = ActionReplaceValues.Split('|');
            var oValues = ActionReplaceOptions.Split('|');

            return new CommandAction()
            {
                Name = ActionReplace,
                Values = aValues.ToList(),
                Options = oValues.ToList()
            };
        }
    }
}
