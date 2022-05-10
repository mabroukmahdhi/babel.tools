//**********************************************************
// Copyright (c) 2022 Mabrouk Mahdhi, Messer SE & Co. KGaA
//**********************************************************
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using System;
using System.Collections.Generic;

namespace Babel.Tools.Infrastructure.Build
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adotnetClient = new ADotNetClient();

            var githubPipeline = new GithubPipeline
            {
                Name = "Babel Tools Pipeline",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.Windows2022,

                        Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Check Out"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setup Dot Net Version",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "6.0.*"
                    }
                },

                new RestoreTask
                {
                    Name = "Restore"
                },

                new DotNetBuildTask
                {
                    Name = "Build"
                },

                new TestTask
                {
                    Name = "Test"
                }
            }
                    }
                }
            };

            adotnetClient.SerializeAndWriteToFile(githubPipeline, "../../../../.github/workflows/dotnet.yml");
        }
    }
}
