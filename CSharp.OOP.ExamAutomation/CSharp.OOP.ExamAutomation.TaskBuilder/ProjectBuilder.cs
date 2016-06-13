
namespace CSharp.OOP.ExamAutomation.TaskBuilder
{
    using System.Collections.Generic;

    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;
    using Microsoft.Build.BuildEngine;
    using Microsoft.Build.Evaluation;

    public class ProjectBuilder
    {
        private string ToolsVersion;

        public ProjectBuilder(IEnumerable<ILogger> loggers, string toolsVersion)
        {
            this.Loggers = loggers;
            this.ToolsVersion = toolsVersion;
        }

        public IEnumerable<ILogger> Loggers { get; set; }

        public bool BuildProject(string projectFilePath)
        {
            var projectCollection = new ProjectCollection();
            projectCollection.DefaultToolsVersion = this.ToolsVersion;
            projectCollection.RegisterLoggers(this.Loggers);

            var project = projectCollection.LoadProject(projectFilePath);
            var buildSucceeded = project.Build();
            return buildSucceeded;
        }
    }
}
