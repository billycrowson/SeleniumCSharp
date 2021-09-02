using NUnit.Framework;
using SeleniumTestProjectCS.Base;
using SeleniumTestProjectCS.Helpers;
using SeleniumTestProjectCS.Pages.TestPlaygroundPages;
using System;

namespace SeleniumTestProjectCS.Tests.TestPlaygroundTests
{
    public class FourthTest : BaseTest
    {

        [Test, Category("Other")]
        public void Test4()
        {
            //Console.WriteLine("Test4");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            heroAvailableExamplesPage heroAvailableExamples = new heroAvailableExamplesPage(driver);
            heroDropdownListPage heroDropdownList = new heroDropdownListPage(driver);

            driver.Click(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            Console.WriteLine(ExcelDataHandler.GetExcelData("HazID", "RadSafteyPW"));

            //Assert.That(heroAvailableExamples.header.Text.Equals("Welcome to the-internet"));

            Assert.Pass();
        }
    }
}