using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WaitHelpers = SeleniumExtras.WaitHelpers;
using SeleniumTestProjectCS.ExtentReporting;
using System;
using AventStack.ExtentReports;

namespace SeleniumTestProjectCS.Helpers
{
    public static class WebElementExtensions
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            ExtentTestManager.GetTest().Log(Status.Info, $"Input [{ text}] into element[{ element}].");
        }

        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(elementName + " is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(elementName + " is not Displayed.");
            }

            return result;
        }

        public static bool IsElementlClickable(this IWebElement element, IWebDriver driver, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        return true;
                    }
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }

        public static void SelectByText(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
            Console.WriteLine(text + " text selected on " + elementName);
        }

        public static void SelectByIndex(this IWebElement element, int index, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByIndex(index);
            Console.WriteLine(index + " index selected on " + elementName);
        }

        public static void SelectByValue(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
            Console.WriteLine(text + " value selected on " + elementName);
        }

        public static string GetElementName(this IWebElement element)
        {
            String ElementName;
            if (String.IsNullOrWhiteSpace(element.GetAttribute("id")) == false)
            {
                ElementName = element.GetAttribute("id");
            }
            else if (String.IsNullOrWhiteSpace(element.GetAttribute("value")) == false)
            {
                ElementName = element.GetAttribute("value");
            }
            else if (String.IsNullOrWhiteSpace(element.GetAttribute("innerHTML")) == false)
            {
                ElementName = element.GetAttribute("innerHTML");
            }
            else { ElementName = element.ToString(); }
            Console.WriteLine("Element name is " + ElementName);

            return ElementName;
        }

    }
}
