using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WaitHelpers = SeleniumExtras.WaitHelpers;
using SeleniumTestProjectCS.ExtentReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace SeleniumTestProjectCS.Helpers
{
    public static class WebDiverExtensions
    {
        public static string ScreenCaptureAsBase64String(this IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }

        public static void BrowserBack(this IWebDriver driver)
        {
            driver.Navigate().Back();
            ExtentTestManager.GetTest().Log(Status.Info, "Navigated Browser back a page");
        }

        public static void SwitchToCurrentWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            String WindowTitle = driver.Title.ToString();
            ExtentTestManager.GetTest().Log(Status.Info, "Switched to "+ WindowTitle +" window");
        }

        public static void ClickSpecifyWait(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                IWebElement toClick = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                    .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                toClick.Click();
            }
            catch (ElementClickInterceptedException)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }
            catch (Exception)
            {
                IWebElement toClick = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                    .Until(WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                toClick.Click();
            }
            ExtentTestManager.GetTest().Log(Status.Info, "Clicked " + by.ToString());

        }

        public static void ClickWaitUpTo30(this IWebDriver driver, By by)
        {
            ClickSpecifyWait(driver, by, 30);
        }

        public static void Click(this IWebDriver driver, By by)
        {
            driver.FindElement(by).Click();
            ExtentTestManager.GetTest().Log(Status.Info, "Clicked " + by.ToString());
        }

        public static void Hovermouse(this IWebDriver driver, By by)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(by)).Perform();
            ExtentTestManager.GetTest().Log(Status.Info, "Hovered mouse over " + by.ToString());
        }

        public static void SendKeys(this IWebDriver driver, By by, String keys)
        {
            IWebElement Element = driver.FindElement(by);

            Element.Clear();
            Element.SendKeys(keys);
            ExtentTestManager.GetTest().Log(Status.Info, "Input " + keys + " into " + by.ToString());
        }

        public static void SendKeysNoClear(this IWebDriver driver, By by, String keys)
        {

            IWebElement Element = driver.FindElement(by);

            Element.SendKeys(keys);
            ExtentTestManager.GetTest().Log(Status.Info, "Input " + keys + " into " + by.ToString());
        }

        public static void SendKeysWaitUpTo10(this IWebDriver driver, By by, String keys)
        {
            IWebElement input = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            input.Clear();
            input.SendKeys(keys);
            ExtentTestManager.GetTest().Log(Status.Info, "Input " + keys + " into " + by.ToString());
        }

        public static void SelectDropdownByValue(this IWebDriver driver, By by, string value)
        {
            IWebElement box = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            SelectElement dropdown = new SelectElement(box);
            dropdown.SelectByValue(value);

            ExtentTestManager.GetTest().Log(Status.Info, "Selected " + value + " from " + by.ToString());
        }

        public static void SelectDropdownByText(this IWebDriver driver, By by, string text)
        {
            IWebElement box = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            SelectElement dropdown = new SelectElement(box);
            dropdown.SelectByText(text);

            ExtentTestManager.GetTest().Log(Status.Info, "Selected " + text + " from " + by.ToString());
        }

        public static void SelectDropdownByIndex(this IWebDriver driver, By by, int index)
        {
            IWebElement box = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            SelectElement dropdown = new SelectElement(box);
            dropdown.SelectByIndex(index);

            ExtentTestManager.GetTest().Log(Status.Info, "Selected " + index + " from " + by.ToString());
        }

        public static void DragAndDrop(this IWebDriver driver, By byFrom, By byTo)
        {
            IWebElement fromDrag = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementToBeClickable(byFrom));

            IWebElement toDrag = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(WaitHelpers.ExpectedConditions.ElementToBeClickable(byTo));

            Actions act = new Actions(driver);
            act.ClickAndHold(fromDrag).MoveToElement(toDrag).MoveByOffset(-5, 0).Release().Build().Perform();

            ExtentTestManager.GetTest().Log(Status.Info, "Dragging " + byFrom.ToString() + " and dropping it on " + byTo.ToString());
        }

        public static void HitEnter(this IWebDriver driver, By by)
        {
            IWebElement input = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            input.SendKeys(Keys.Enter);

            ExtentTestManager.GetTest().Log(Status.Info, "Hit [Enter] on " + by.ToString());
        }

        public static void HitDown(this IWebDriver driver, By by)
        {
            IWebElement input = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            input.SendKeys(Keys.ArrowDown);

            ExtentTestManager.GetTest().Log(Status.Info, "Hit [Down Arrow] on " + by.ToString());
        }

        public static void HitTab(this IWebDriver driver, By by)
        {
            IWebElement input = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            input.SendKeys(Keys.Tab);

            ExtentTestManager.GetTest().Log(Status.Info, "Hit [Tab] on " + by.ToString());
        }

        public static void HitEscape(this IWebDriver driver, By by)
        {
            IWebElement input = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            input.SendKeys(Keys.Escape);

            ExtentTestManager.GetTest().Log(Status.Info, "Hit [Escape] on " + by.ToString());
        }

        public static void CheckBox(this IWebDriver driver, By by)
        {
            if (!driver.FindElement(by).Selected)
            {
                Click(driver, by);
                ExtentTestManager.GetTest().Log(Status.Info, "Checked box " + by.ToString());
            }
        }

        public static void UncheckBox(this IWebDriver driver, By by)
        {
            if (driver.FindElement(by).Selected)
            {
                Click(driver, by);
                ExtentTestManager.GetTest().Log(Status.Info, "Unchecked box " + by.ToString());
            }
        }

        public static void ClearTextBox(this IWebDriver driver, By by)
        {
            IWebElement Element = driver.FindElement(by);

            try
            {
                Element.Clear();
            }
            catch (Exception)
            {
                Element.SendKeys(Keys.Control + "a");
                Element.SendKeys(Keys.Delete);
            }

            ExtentTestManager.GetTest().Log(Status.Info, "Cleared " + by.ToString());
        }

        public static void WaitForVisibility(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(WaitHelpers.ExpectedConditions.ElementIsVisible(by)); ;

            ExtentTestManager.GetTest().Log(Status.Info, "Waiting for " + by.ToString() + " to be visible");
        }

        public static void WaitForInisibility(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));

            ExtentTestManager.GetTest().Log(Status.Info, "Waiting for " + by.ToString() + " to be visible");
        }

        public static void VerifyContainsText(this IWebDriver driver, By by, String text)
        {
            try
            {
                Assert.That(driver.FindElement(by).Text.Contains(text));
                ExtentTestManager.GetTest().Log(Status.Info, "Element " + by.ToString() + " contains text " + text);
            }
            catch (AssertionException)
            {
                throw new AssertionException("Element " + by.ToString() + " does NOT contain text " + text);
            }
        }

        public static void VerifyEqualsText(this IWebDriver driver, By by, String text)
        {
            try
            {
                Assert.That(driver.FindElement(by).Text.Equals(text));
                ExtentTestManager.GetTest().Log(Status.Info, "Element " + by.ToString() + " equals text " + text);
            }
            catch (AssertionException)
            {
                throw new AssertionException("Element " + by.ToString() + " does NOT equal text " + text);
            }
        }

        public static void VerifyIsSelected(this IWebDriver driver, By by)
        {
            try
            {
                Assert.That(driver.FindElement(by).Selected);
                ExtentTestManager.GetTest().Log(Status.Info, "Element " + by.ToString() + " is selected");
            }
            catch (AssertionException)
            {
                throw new AssertionException("Element " + by.ToString() + " is NOT selected when it should be");
            }
        }

        public static void VerifyIsNotSelected(this IWebDriver driver, By by)
        {
            try
            {
                Assert.That(driver.FindElement(by).Selected, Is.Not.False);
                ExtentTestManager.GetTest().Log(Status.Info, "Element " + by.ToString() + " is not selected");
            }
            catch (AssertionException)
            {
                throw new AssertionException("Element " + by.ToString() + " is selected when it should NOT be");
            }
        }

        public static void UploadTestFile(this IWebDriver driver, By by)
        {
            //Need to add files to project
            driver.FindElement(by).SendKeys("Location of files");
            ExtentTestManager.GetTest().Log(Status.Info, "Uploaded Test File from " + "filelocation" + " to "+ by.ToString());
        }

    }
}
