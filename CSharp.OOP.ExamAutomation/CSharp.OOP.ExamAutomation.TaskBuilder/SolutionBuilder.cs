namespace CSharp.OOP.ExamAutomation.TaskBuilder
{
    using System.Collections.Generic;

    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;

    public class SolutionBuilder
    {
        private readonly string BuildToolsVersion;
        private readonly string Configuration;
        private readonly string[] TargetsToBuild;
        private readonly HostServices HostServices;

        public SolutionBuilder(
            IEnumerable<ILogger> loggers,
            string[] targetsToBuild,
            string buildToolsVersion,
            string configuration,
            HostServices hostServices)
        {
            this.Loggers = loggers;
            this.HostServices = hostServices;
            this.Configuration = configuration;
            this.TargetsToBuild = targetsToBuild;
            this.BuildToolsVersion = buildToolsVersion;
        }

        public IEnumerable<ILogger> Loggers { get; set; }

        public bool BuildSolution(string solutionFilePath)
        {
            var globalProperties = new Dictionary<string, string>();
            globalProperties["Configuration"] = this.Configuration;

            var buildRequest = new BuildRequestData(
                solutionFilePath,
                globalProperties,
                this.BuildToolsVersion,
                this.TargetsToBuild,
                this.HostServices);

            var buildParams = new BuildParameters();
            buildParams.Loggers = this.Loggers;

            var result = BuildManager.DefaultBuildManager.Build(buildParams, buildRequest);
            var buildSucceeded = result.OverallResult == BuildResultCode.Success;
            return buildSucceeded;
        }
    }
}
