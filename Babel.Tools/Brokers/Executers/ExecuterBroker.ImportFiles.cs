//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Outputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace Babel.Tools.Brokers.Executers
{
    public partial class ExecuterBroker
    {
        private const string importFilesAboutFile = "Texts\\AboutIFCommand.txt";
        private const string exportFilesTo = @"T:\08 - Information Technology\0803 -IT Support\J Laufwerk\04 - Dokumente\0407 - Systemdokumentation\040702 - Babel\Stammdatenimport";

        private OutputCollection ExecuteImportFilesCommand(ImportFilesCommand command)
        {
            if (command.IsHelpAction)
            {
                return ReturnAboutFile(Path.Combine(assemlyLocation, importFilesAboutFile));
            }

            if (command.IsAdjustAction)
            {
                return ExecuteAdjustImportFilesCommand(command);
            }

            if (command.IsUploadAction)
            {
                return ExecuteUploadImportFilesCommand(command);
            }


            // Do other actions...
            return ReturnNoCommandCanBeRun();
        }



        private OutputCollection ExecuteAdjustImportFilesCommand(ImportFilesCommand command)
        {
            OutputCollection outputs = new();

            outputs.Log("********************************************");
            outputs.Log($"Date : {DateTime.Now.ToLongDateString()}");
            outputs.Log("********************************************");
            outputs.Log("Setting columns with to [AutoFit] started...");

            var filePaths = GetExcelFiles();

            if (filePaths == null || !filePaths.Any())
            {
                var msg = $"No excel files in this directory... ";
                outputs.Error(msg);
                return outputs;
            }
            var xlApp = new Excel.Application();
            foreach (var item in filePaths)
            {
                try
                {
                    var xlWorkBook = xlApp.Workbooks.Open(item);
                    var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                    xlWorkSheet.Columns.AutoFit();
                    xlWorkBook.Save();
                    xlWorkBook.Close();
                    var msg = $"[Done] => {Path.GetFileName(item)}";
                    outputs.Info(msg);
                }
                catch (Exception ex)
                {
                    var msg = $"[Failed] => {Path.GetFileName(item)} => {ex}";
                    outputs.Error(msg);
                }
            }
            var endmsg = "Setting columns with to [AutoFit] ended... ";
            outputs.Log(endmsg);
            CreateLogFile(outputs.ToString());

            return outputs;
        }


        private OutputCollection ExecuteUploadImportFilesCommand(ImportFilesCommand command)
        {
            OutputCollection outputs = new();

            string destFolder = Path.Combine(
                exportFilesTo,
                DateTime.Now.ToString("yyyy"),
                DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
                outputs.Info($"New folder '{destFolder}' was successfully created.");
            }
            else
            {
                outputs.Info($"'{destFolder}' exists already.");
            }

            var files = GetExcelFiles();

            outputs.Log($"{files?.Count() ?? 0} file(s) was found in folder '{Directory.GetCurrentDirectory()}'.");

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destFolder, fileName);
                File.Copy(file, destFile, overwrite: command.HasOptionOverwrite);
                outputs.Info($"{fileName} successfully copied to: {destFile}.");
            }

            return outputs;
        }


        private IEnumerable<string> GetExcelFiles()
            => Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.TopDirectoryOnly)?
                           .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx") || s.EndsWith(".xlsb"));

        private static void CreateLogFile(string text)
        {
            string file = @".\LOGS.TXT";
            var log = File.Exists(file) ? File.ReadAllText(file) : string.Empty;
            File.WriteAllText(file, $"{log}\n\n{text}");
        }
    }
}
