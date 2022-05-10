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
    public class ImportFilesCommand : BabelCommand
    {
        private const string ActionAdjust = "adjust";
        private const string ActionUpload = "upload";
        private const string ActionAdjustValues = "-a|--adjust";
        private const string ActionUploadValues = "-u|--upload";
        private const string ActionUploadOptions = "-o|--overwrite";
        public ImportFilesCommand(string runAction)
            : base(runAction, Array.Empty<string>())
        { }

        public override string Name => ImportFilesCommandName;

        public override IEnumerable<CommandAction> Actions
            => GenerateActions();

        public bool IsAdjustAction
           => ActionAdjustValues.Split('|')
                           .Any(o => o.Equals(RunAction, StringComparison.OrdinalIgnoreCase));

        public bool IsUploadAction
          => ActionUploadValues.Split('|')
                          .Any(o => o.Equals(RunAction, StringComparison.OrdinalIgnoreCase));

        public bool HasOptionOverwrite
           => RunOptions?.Any(i => ActionUploadOptions.Split('|').Contains(i.ToLower())) ?? false;


        protected override List<CommandAction> GenerateActions()
         => new()
         {
             GenerateHelpAction(),
             GenerateAdjustAction(),
             GenerateUploadAction()
         };

        private CommandAction GenerateAdjustAction()
        {
            var aValues = ActionAdjustValues.Split('|');

            return new CommandAction()
            {
                Name = ActionAdjust,
                Values = aValues.ToList()
            };
        }

        private CommandAction GenerateUploadAction()
        {
            var aValues = ActionUploadValues.Split('|');

            return new CommandAction()
            {
                Name = ActionUpload,
                Values = aValues.ToList()
            };
        }
    }
}
