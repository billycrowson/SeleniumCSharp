using NUnit.Framework;
using SeleniumTestProjectCS.Base;
using SeleniumTestProjectCS.Helpers;
using SeleniumTestProjectCS.Pages.TestPlaygroundPages;
using System;

namespace SeleniumTestProjectCS.Tests.TestPlaygroundTests
{
    public class SecondTest : BaseTest
    {

        [Test, Category("Test Playground")]
        public void Test2()
        {
            Console.WriteLine("Test2");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            heroAvailableExamplesPage heroAvailableExamples = new heroAvailableExamplesPage(driver);
            heroDropdownListPage heroDropdownList = new heroDropdownListPage(driver);

            driver.Click(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            Console.WriteLine(ExcelDataHandler.GetExcelData("IRBe", "IRBeID"));

            driver.VerifyEqualsText(heroAvailableExamples.header, "Welcome to the-interne");
        }
    }
}