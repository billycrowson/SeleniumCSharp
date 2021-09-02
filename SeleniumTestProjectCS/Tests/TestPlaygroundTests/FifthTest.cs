using NUnit.Framework;
using SeleniumTestProjectCS.Base;
using SeleniumTestProjectCS.Helpers;
using SeleniumTestProjectCS.Pages.TestPlaygroundPages;
using System;

namespace SeleniumTestProjectCS.Tests.TestPlaygroundTests
{
    public class FifthTest : BaseTest
    {

        [Test, Category("Other")]
        public void Test5()
        {
            Console.WriteLine("Test5");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            heroAvailableExamplesPage heroAvailableExamples = new heroAvailableExamplesPage(driver);
            heroDropdownListPage heroDropdownList = new heroDropdownListPage(driver);

            driver.Click(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            Console.WriteLine(ExcelDataHandler.GetExcelData("GnC", "KafUN"));

            //Assert.That(heroAvailableExamples.header.Text.Equals("Welcome to the-internet"));

            Assert.Pass();
        }
    }
}