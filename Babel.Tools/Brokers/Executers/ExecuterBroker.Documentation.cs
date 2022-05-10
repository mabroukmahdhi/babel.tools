//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using Babel.Tools.Models.Commands;
using Babel.Tools.Models.Outputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Babel.Tools.Brokers.Executers
{
    public partial class ExecuterBroker
    {
        private const string docuAboutFile = "Texts\\AboutDocuCommand.txt";
        private OutputCollection ExecuteDocumentationCommand(DocumentationCommand command)
        {
            if (command.IsHelpAction)
            {
                return ReturnAboutFile(Path.Combine(assemlyLocation, docuAboutFile));
            }

            if (command.IsReplaceAction)
            {
                return ExecuteReplaceDocumentationCharsCommand(command);
            }
            // Do other actions...
            return ReturnNoCommandCanBeRun();
        }


        private OutputCollection ExecuteReplaceDocumentationCharsCommand(DocumentationCommand command)
        {
            OutputCollection outputs = new();

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");

            string folder = Directory.GetCurrentDirectory();

            string[] files = null;

            if (command.HasOptionIgnore)
            {
                files = Directory.GetFiles(folder, "*.htm");
            }
            else
            {
                files = Directory.GetFiles(folder, "*.htm", SearchOption.AllDirectories);
            }

            if (files == null || files.Any() == false)
            {
                outputs.Error($"No files found in the folder {folder}.");
                return outputs;
            }

            Dictionary<char, string> specialChars = new Dictionary<char, string>() {
                { 'ä',"&auml;"},
                { 'ö',"&ouml;"},
                { 'ü',"&uuml;"},
                { 'Ä',"&Auml;"},
                { 'Ö',"&Ouml;"},
                { 'Ü',"&Uuml;"},
                { '\'',"&#39;"},
            };

            outputs.Info($"{files.Count()} files found under {folder}.");
            int count = 0;
            try
            {
                foreach (var file in files)
                {

                    string fileText = File.ReadAllText(file, encoding);
                    bool update = false;

                    foreach (char key in specialChars.Keys)
                    {
                        if (fileText.Contains(key) == false)
                            continue;
                        fileText = fileText.Replace($"{key}", specialChars[key]);

                        outputs.Log($"All '{key}' chars are changed to '{specialChars[key]}' " +
                                    $"in the file: {file}.");

                        update = true;
                    }
                    if (Regex.IsMatch(fileText, @"<\s*body\s*>"))
                    {
                        fileText = Regex.Replace(fileText, @"<\s*body\s*>",
                                                        "<body style=\"font-family: calibri;\">");
                        update = true;
                        outputs.Log($"Font-family set to file {file}.");
                    }
                    if (update == false)
                    {
                        continue;
                    }
                    count++;
                    outputs.Info($"Successfully updated : {file} ...");

                    File.WriteAllText(file, fileText, encoding);
                }

                if (count == 0)
                {
                    outputs.Warn($"No file was changed, " +
                        $"if you think this result is not correct " +
                        $"please check the source folder, now you are here: {folder}.");
                }
                else
                {
                    outputs.Warn($"{count} file(s) was changed!");
                }
            }
            catch (Exception ex)
            {
                outputs.Error(ex.ToString());
            }

            return outputs;
        }
    }
}
