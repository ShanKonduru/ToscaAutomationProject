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
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickRegisterLink()
        {
            var registerLink = FindElement(By.CssSelector("a[href='/register'].ico-register"));
            registerLink.Click();
        }

        public void ClickLoginLink()
        {
            var loginLink = FindElement(By.CssSelector("a[href='/login'].ico-login"));
            loginLink.Click();
        }

        public string GetShoppingCartItemCount()
        {
            var shoppingCartCount = FindElement(By.CssSelector("div.mini-shopping-cart > div.count"));
            return shoppingCartCount.Text.Trim();
        }

        public void ClickWishlist()
        {
            var wishlistLabel = FindElement(By.CssSelector("span.cart-label"));
            wishlistLabel.Click();
        }
    }
}
