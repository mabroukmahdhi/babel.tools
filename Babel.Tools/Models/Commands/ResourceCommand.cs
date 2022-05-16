//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Tools.Models.Commands
{
    public class ResourceCommand : BabelCommand
    {
        private const string ActionImport = "import";
        private const string ActionExport = "export";
        private const string ActionImportValues = "-i|--import";
        private const string ActionExportValues = "-e|--export";
        public ResourceCommand(string runAction, params string[] runOptions)
            : base(runAction, runOptions)
        { }

        public override string Name => ResourceCommandName;

        public override IEnumerable<CommandAction> Actions
            => GenerateActions();

        public bool IsImportAction
           => ActionImportValues.Split('|')
                           .Any(o => o.Equals(RunAction, StringComparison.OrdinalIgnoreCase));

        public bool IsExportAction
          => ActionExportValues.Split('|')
                          .Any(o => o.Equals(RunAction, StringComparison.OrdinalIgnoreCase));

        protected override List<CommandAction> GenerateActions()
        => new()
        {
            GenerateHelpAction(),
            GenerateImportAction(),
            GenerateExportAction()
        };

        private CommandAction GenerateImportAction()
        {
            var aValues = ActionImportValues.Split('|');

            return new CommandAction()
            {
                Name = ActionImport,
                Values = aValues.ToList()
            };
        }

        private CommandAction GenerateExportAction()
        {
            var aValues = ActionExportValues.Split('|');

            return new CommandAction()
            {
                Name = ActionExport,
                Values = aValues.ToList()
            };
        }
    }
}
