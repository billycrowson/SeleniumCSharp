using OpenQA.Selenium;
using SeleniumTestProjectCS.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProjectCS.Pages.TestPlaygroundPages
{
    class heroLoginPage : BasePage
    {
        public heroLoginPage(IWebDriver driver) : base(driver) { }

        public By tboxUsername => By.XPath("//input[@id='username']");
        public By tboxPassword => By.XPath("//input[@id='password']");
        public By btnLogin => By.XPath("//button[@type='submit']");
    }
}
