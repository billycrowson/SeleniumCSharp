using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumTestProjectCS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProjectCS.Pages.TestPlaygroundPages
{
    public class heroAvailableExamplesPage : BasePage
    {
        public heroAvailableExamplesPage(IWebDriver driver) : base(driver) { }

        public By header => By.XPath("//h1");
        public By lnkDropdown => By.XPath("//a[normalize-space()='Dropdown']");
        public By lnkFormAuthentication => By.XPath("//a[normalize-space()='Form Authentication']");
    }
}
