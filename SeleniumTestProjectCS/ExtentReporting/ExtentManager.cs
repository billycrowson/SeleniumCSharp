using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace SeleniumTestProjectCS.ExtentReporting
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentManager()
        {
            var htmlReporter = new ExtentHtmlReporter(@"..\..\..\zReports\");
            htmlReporter.Config.DocumentTitle = "Test Automation Results";
            htmlReporter.Config.ReportName ="Test Automation Results";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.EnableTimeline = true;

            Instance.AddSystemInfo("Machine", Environment.MachineName);
            Instance.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}
