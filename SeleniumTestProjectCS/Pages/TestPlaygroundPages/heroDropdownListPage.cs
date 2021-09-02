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
    class heroDropdownListPage : BasePage
    {
        public heroDropdownListPage(IWebDriver driver) : base(driver) { }

        public By drpDropdown => By.XPath("//select[@id='dropdown']");
    }
}
