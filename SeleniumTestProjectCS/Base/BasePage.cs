using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProjectCS.Base
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected BasePage(IWebDriver driver) => Driver = driver;
    }
}
