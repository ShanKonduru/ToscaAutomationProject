
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace tricentis.qtest.demowebshop
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        protected IWebElement FindElement(By locator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}

