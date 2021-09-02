using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestProjectCS.Base
{
    public class Setup
    {
		public IWebDriver driver;
		public IWebDriver initializeDriver()
        {
			String browserName = TestContext.Parameters["browser"];

			if(browserName == null || browserName == "")
            {
				browserName = "chrome";
			}

			//Initialize browser driver based on what is set in properties
			if (browserName.Contains("chrome"))
			{
				new DriverManager().SetUpDriver(new ChromeConfig());
				ChromeOptions options = new ChromeOptions();
				options.AddArguments("--ignore-certificate-errors");

				//Runs Chrome in headless mode if it is added in browserName
				if (browserName.Contains("headless"))
				{

					options.AddArguments("headless");
				}

				driver = new ChromeDriver(options);
			}

			else if (browserName.Equals("firefox"))
			{
				new DriverManager().SetUpDriver(new FirefoxConfig());
				driver = new FirefoxDriver();
			}

			else if (browserName.Equals("edge"))
			{
				new DriverManager().SetUpDriver(new EdgeConfig());
				driver = new EdgeDriver();
			}

			//Maximize browser
			driver.Manage().Window.Maximize();

			return driver;
		}
    }
}
