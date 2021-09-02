using NUnit.Framework;
using SeleniumTestProjectCS.Base;
using SeleniumTestProjectCS.Helpers;
using SeleniumTestProjectCS.Pages.TestPlaygroundPages;
using System;
using System.Data;
using System.Linq;

namespace SeleniumTestProjectCS.Tests.TestPlaygroundTests
{
    public class ThirdTest : BaseTest
    {

        [Test, Category("Test Playground")]
        public void Test3()
        {
            Console.WriteLine("Test3");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            heroAvailableExamplesPage heroAvailableExamples = new heroAvailableExamplesPage(driver);
            heroDropdownListPage heroDropdownList = new heroDropdownListPage(driver);

            driver.Click(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            ExcelDataHandler.SetExcelData("HazID", "VilerPW", "1234");

            Assert.Pass();
        }
    }
}