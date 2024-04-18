﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/*
// The source code was generated by cSharpSeleniumGenerator.js
// Copyright: Tricentis
// Website: https://www.tricentis.com
// C# plugin version: 1.3.4
*/
namespace MyNamespace1
{
    [TestClass]
    public class MyTestCase1
    {
        private IWebDriver _driver;
        private const int MOUSE_LEFT = 0;
        private const int MOUSE_RIGHT = 2;
        private const bool alwaysExecuteActionInLatestWindow = true;

        [TestInitialize]
        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/login");
        }

        [TestMethod]
        public void Test()
        {
            Click(null, By.XPath("html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div[1]/div[3]/input"), MOUSE_LEFT, 1);
            Click(null, By.Id("gender-male"), MOUSE_LEFT, 3);
            SendKeys(null, By.Id("FirstName"), "User", true, 16);
            SendKeys(null, By.Id("LastName"), "One", true, 3);
            SendKeys(null, By.Id("Email"), "UserOne@UserOne.com", true, 3);
            SendKeys(null, By.Id("Password"), "********", true, 13);
            SendKeys(null, By.Id("ConfirmPassword"), "********", true, 4);
            Click(null, By.Id("register-button"), MOUSE_LEFT, 5);
            Click(null, By.XPath("html/body/div[4]/div[1]/div[4]/div[2]/div/div[2]/div[2]/input"), MOUSE_LEFT, 11);
        }

        /// <summary>
        /// Switches to an iframe.
        /// </summary>
        /// <param name="framesJson">
        /// The json frames. ex: [{"value":"child2","type":"id_or_name"}]
        /// "type" should be "id or value" or "index"
        /// </param>
        private void SwitchToFrames(string framesJson)
        {
            try
            {
                _driver.SwitchTo().DefaultContent();
                var array = JsonConvert.DeserializeObject<JArray>(framesJson);
                var children = array.Children<JObject>();
                foreach (var obj in children)
                {
                    var type = obj.GetValue("type").ToString();
                    var value = obj.GetValue("value").ToString();
                    // switch to desired frame/iframe
                    if (type.ToLower() == "index")
                    {
                        _driver.SwitchTo().Frame(int.Parse(value));
                    }
                    else
                    {
                        _driver.SwitchTo().Frame(value);
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Sends the keys to the UI element
        /// </summary>
        /// <param name="locator">The element locator</param>
        /// <param name="keys">The keys to send to the element
        /// <param name="clearTextBeforeSendingKeys">if true, clear the text field before sending keys to it, otherwise, false
        /// <param name="timeOutInSeconds">The time out, in seconds, to find element</param>
        public void SendKeys(String frames, By locator, string keys, bool clearTextBeforeSendingKeys, int timeOutInSeconds)
        {
            if (alwaysExecuteActionInLatestWindow) SwitchToLastWindow(frames);
            IWebElement elm = FindElement(locator, timeOutInSeconds);
            if (clearTextBeforeSendingKeys) elm.Clear();
            elm.SendKeys(keys);
        }

        /// <summary>
        /// Clicks the specified UI element.
        /// </summary>
        /// <param name="locator">The element locator.</param>
        /// <param name="mouseButton">The mouse button, e.g. MOUSE_LEFT, MOUSE_RIGHT.</param>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        public void Click(String frames, By locator, int mouseButton, int timeoutInSeconds)
        {
            Click(frames, locator, mouseButton, null, timeoutInSeconds);
        }

        /// <summary>
        /// Clicks on the specified UI element.
        /// </summary>
        /// <param name="locator">The element locator.</param>
        /// <param name="mouseButton">The mouse button.</param>
        /// <param name="modifierKeys">The modifier keys.</param>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        /// <exception cref="NoSuchElementException">Element not found.</exception>
        /// <exception cref="Exception">Failed to click on the element</exception>
        public void Click(String frames, By locator, int mouseButton, string modifierKeys, int timeoutInSeconds)
        {
            if (alwaysExecuteActionInLatestWindow) SwitchToLastWindow(frames);
            bool success = false;
            long timeoutInMillies = timeoutInSeconds * 1000;
            IWebElement elm = null;
            // time spent counters
            long timeSpentInMillis = 0;
            // try to click on the element until wait timout reached
            while ((success == false) && (timeSpentInMillis <= timeoutInMillies))
            {
                try
                {
                    Stopwatch stopWatch = Stopwatch.StartNew();
                    // find the element and calculate time spent
                    elm = FindElement(locator, 1);
                    stopWatch.Stop();
                    timeSpentInMillis += stopWatch.ElapsedMilliseconds;
                    if (elm != null)
                    {
                        PerformClick(elm, mouseButton, modifierKeys);
                        // successfully clicked on element, turn on the flag to escape the loop
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    // probably the element is not present yet or it is non-clickable
                    Console.WriteLine(e.Message);
                    // if element is found and we reached to the timeout, try to click on it with JavaScript
                    if ((elm != null) && (timeSpentInMillis > timeoutInMillies))
                    {
                        IJavaScriptExecutor js = (IJavaScriptExecutor)this._driver;
                        js.ExecuteScript("arguments[0].click();", elm);
                        // successfully clicked on element, turn on the flag to escape the loop
                        success = true;
                    }
                }
            }

            if (!success)
            {
                if (elm == null)
                {
                    throw new NoSuchElementException("Element not found.");
                }
                else
                {
                    throw new Exception("Failed to click on the element");
                }
            }
        }

        private void PerformClick(IWebElement element, int mouseButton, string modifierKeys)
        {
            modifierKeys = modifierKeys ?? string.Empty;
            if (string.IsNullOrEmpty(modifierKeys) && (mouseButton == MOUSE_LEFT))
            {
                element.Click();
                return;
            }

            var actions = new Actions(_driver);
            if (modifierKeys.IndexOf("Ctrl") > -1)
            {
                actions = actions.KeyDown(Keys.Control);
            }

            if (modifierKeys.IndexOf("Alt") > -1)
            {
                actions = actions.KeyDown(Keys.Alt);
            }

            if (modifierKeys.IndexOf("Shift") > -1)
            {
                actions = actions.KeyDown(Keys.Shift);
            }

            if (mouseButton == MOUSE_LEFT)
            {
                actions = actions.Click(element);
            }
            else
            {
                actions = actions.ContextClick(element);
            }

            if (modifierKeys.IndexOf("Ctrl") > -1)
            {
                actions = actions.KeyUp(Keys.Control);
            }

            if (modifierKeys.IndexOf("Alt") > -1)
            {
                actions = actions.KeyUp(Keys.Alt);
            }

            if (modifierKeys.IndexOf("Shift") > -1)
            {
                actions = actions.KeyUp(Keys.Shift);
            }
            actions.Perform();
        }

        /// <summary>
        /// Finds the element by a locator
        /// </summary>
        /// <param name="locator">The element locator.</param>
        /// <param name="waitForElementTimeoutInSeconds">The timeout, in seconds, to wait for element.</param>
        /// <returns></returns>
        private IWebElement FindElement(By locator, int waitForElementTimeoutInSeconds)
        {
            while (true)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitForElementTimeoutInSeconds));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                }
                catch (WebDriverTimeoutException)
                {
                    // sometimes WebDriverWait falied to find elements, e.g. Dojo checkboxs, and we need to fall back to use WebDriver itself
                    return _driver.FindElement(locator);
                }
                catch (UnhandledAlertException)
                {
                    // Alert dialog is about to be closed, wait a moment and retry
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Select an option in a select element
        /// </summary>
        /// <param name="frames">frame list, where select tag belong to</param>
        /// <param name="selectElementLocator">locator of select element</param>
        /// <param name="waitForElementTimeout">wait time out</param>
        /// <param name="text">text to select</param>
        public void SelectItemByVisibleText(String frames, By selectElementLocator, int waitForElementTimeout, String text)
        {
            if (alwaysExecuteActionInLatestWindow) SwitchToLastWindow(frames);
            SelectElement sel = new SelectElement(FindElement(selectElementLocator, waitForElementTimeout));
            sel.SelectByText(text);
        }

        /// <summary>
        /// Switch to lastest window and frames
        /// </summary>
        /// <param name="frameList">List of frame to switch or null</param>
        private void SwitchToLastWindow(String frameList)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            if (null != frameList) SwitchToFrames(frameList);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
