using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumTestProjectCS.ExtentReporting;
using SeleniumTestProjectCS.Helpers;
using System.IO;

namespace SeleniumTestProjectCS.Base
{
    [Parallelizable]
    [TestFixture]
    public class BaseTest : Setup
    {

        [OneTimeSetUp]
        public void Setup()
        {
            driver = initializeDriver();
        }

        [SetUp]
        public void StartUpTest()
        {
            var category = (string)TestContext.CurrentContext.Test.Properties.Get("Category");
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory(category);
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    ExtentTestManager.GetTest().Log(logstatus, $"Error Message: <br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(driver.ScreenCaptureAsBase64String()).Build());
                    // Get the screenshot from Selenium WebDriver and save it to a file
                    ITakesScreenshot ts = (ITakesScreenshot)driver;
                    Screenshot screenshot = ts.GetScreenshot();
                    string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory, TestContext.CurrentContext.Test.Name+"_failed_screenshot.png");
                    screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);

                    // Add that file to NUnit results
                    TestContext.AddTestAttachment(screenshotFile, "Screenshot of Failure");
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ExtentManager.Instance.Flush();
            driver.Close();
            driver.Quit();
        }

    }
}
