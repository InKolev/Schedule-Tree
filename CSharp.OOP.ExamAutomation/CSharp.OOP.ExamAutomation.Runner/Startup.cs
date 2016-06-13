namespace CSharp.OOP.ExamAutomation.Runner
{
    using System.Collections.Generic;
    using System.Reflection;
    using TaskBuilder;

    using Microsoft.Build.BuildEngine;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;
    using System.Linq;
    using System;
    using System.IO;
    public class Startup
    {
        static void Main(string[] args)
        {
            // Setup paths
            var basePath = @"D:\Exams\";
            var examPaths = Directory.GetDirectories(basePath);

            foreach (var userExamPath in examPaths)
            {
                var solutionFilePath = Directory.GetFiles(userExamPath).FirstOrDefault(x => x.Contains(".sln"));
                //var spaceCoreDllFilePath = @"D:\BuildTestSolution\Space.Core\bin\Release\Space.Core.dll";
                //var spaceModelsDllFilePath = @"D:\BuildTestSolution\Space.Core\bin\Release\Space.Models.dll";
                //var projectFilePath = "D:\\BuildTestSolution\\Space.Models\\Space.Models.csproj";

                // Setup solution builder parameters
                string[] targetsToBuild = new string[] { "Build" };
                string buildToolsVersion = null;
                string configuration = "Release";
                HostServices hostServices = null;

                // Setup loggers
                //TODO: Add text file logger with userName credentials applied as file name
                var consoleLogger = new ConsoleLogger();
                var loggers = new List<ILogger>();
                loggers.Add(consoleLogger);

                // Solution builder
                var solutionBuilder = new SolutionBuilder(
                    loggers,
                    targetsToBuild,
                    buildToolsVersion,
                    configuration,
                    hostServices);

                var buildSuccessful = solutionBuilder.BuildSolution(solutionFilePath);

                var solutionDLLs = Directory.GetFiles(userExamPath + @"\Space.Core\bin\Release")
                    .Where(x=> x.Contains(".dll"))
                    .ToList();

                var assemblies = new List<Assembly>();

                foreach(var solutionDLL in solutionDLLs)
                {
                    assemblies.Add(Assembly.LoadFrom(solutionDLL));
                }

                // Load DLL's
                var allTypes = assemblies.SelectMany(x=>x.GetTypes()).ToList();
                var xDragonLauncher = allTypes.FirstOrDefault(x => x.Name == "XDragonLauncher");
                var xDragonLauncherModelProperty = xDragonLauncher
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(x => x.Name == "Model");
                var isXDragonLauncherModelPropertyGetMethodPrivate = xDragonLauncherModelProperty.GetGetMethod(true).IsPrivate;
                var isXDragonLauncherModelPropertySetMethodPrivate = xDragonLauncherModelProperty.GetSetMethod(true).IsPrivate;

                Console.WriteLine($"Get Method Is Private: {isXDragonLauncherModelPropertyGetMethodPrivate}");
                Console.WriteLine($"Set Method Is Private: {isXDragonLauncherModelPropertySetMethodPrivate}");
            }
        }
    }
}
