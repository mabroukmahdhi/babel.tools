//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace Babel.Tools.Brokers.Executers
{
    public partial class ExecuterBroker
    {
        private const string resourceAboutFile = "Texts\\AboutResourceCommand.txt";
        private const string importScript = @".\Localizer.exe /p '..\..\BabelWmControls\Resources' /r BABEL /i /a '..\..\..\BabelDroid\BabelDroid\Resources'";
        private const string exportScript = @".\Localizer.exe /p ..\..\BabelWmControls\Resources /r BABEL /e";
        private const string toolsFolder = @"C:\C#\BABEL III\WindowsMobile\exttools\ResourceTools";
        private const string wmFolder = @"C:\C#\BABEL III\WindowsMobile";
        private const string droidFolder = @"C:\C#\BABEL III\BabelDroid";
        private OutputCollection ExecuteResourceCommand(ResourceCommand command)
        {
            if (command.IsHelpAction)
            {
                return ReturnAboutFile(Path.Combine(assemlyLocation, resourceAboutFile));
            }

            if (command.IsImportAction)
            {
                return ExecuteImportReourcesCommand(command);
            }

            if (command.IsExportAction)
            {
                return ExecuteExportReourcesCommand(command);
            }


            // Do other actions...
            return ReturnNoCommandCanBeRun();
        }

        private OutputCollection ExecuteExportReourcesCommand(ResourceCommand command)
        {
            var output = new OutputCollection();
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = toolsFolder,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    Arguments = $"/C {exportScript}",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                Process.Start(startInfo);
                output.Log($"Command : {exportScript}.");
            }
            catch (Exception ex)
            {
                output.Error(ex.Message);
            }
            return output;
        }

        private OutputCollection ExecuteImportReourcesCommand(ResourceCommand command)
        {
            var output = new OutputCollection();
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = toolsFolder,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    Arguments = $"/C {importScript}",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                Process.Start(startInfo);
                output.Log($"Command : {importScript}.");
            }
            catch (Exception ex)
            {
                output.Error(ex.Message);
            }
            return output;
        }
    }
}
