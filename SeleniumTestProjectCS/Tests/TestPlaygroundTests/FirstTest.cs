using NUnit.Framework;
using SeleniumTestProjectCS.Base;
using SeleniumTestProjectCS.Pages.TestPlaygroundPages;
using SeleniumTestProjectCS.Helpers;
using System;
using System.IO;

namespace SeleniumTestProjectCS.Tests.TestPlaygroundTests
{
    public class FirstTest : BaseTest
    {
        
        [Test,Category("Test Playground")]
        public void Test1()
        {
            Console.WriteLine("Test1");
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            heroAvailableExamplesPage heroAvailableExamples = new heroAvailableExamplesPage(driver);
            heroDropdownListPage heroDropdownList = new heroDropdownListPage(driver);
            heroLoginPage heroLogin = new heroLoginPage(driver);

            driver.ClickSpecifyWait(heroAvailableExamples.lnkDropdown, 30);
            driver.BrowserBack();

            driver.ClickWaitUpTo30(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            driver.Click(heroAvailableExamples.lnkDropdown);
            driver.BrowserBack();

            driver.Click(heroAvailableExamples.lnkFormAuthentication);

            driver.SendKeysWaitUpTo10(heroLogin.tboxUsername, "username");
            driver.SendKeysWaitUpTo10(heroLogin.tboxPassword, "password");
            driver.Click(heroLogin.btnLogin);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.VerifyContainsText(heroAvailableExamples.header, "Welcome to the-interne");
            driver.VerifyEqualsText(heroAvailableExamples.header, "Welcome to the-internet");

            Console.WriteLine(ExcelDataHandler.GetExcelData("HazID", "ProfileLastName"));

            //Assert.Pass();
        }
    }
}