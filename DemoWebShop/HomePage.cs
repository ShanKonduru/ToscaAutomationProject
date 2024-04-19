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
using Shan.WebAutomationFramework;

namespace tricentis.qtest.demowebshop
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        
        public IWebElement UserNameInput => _driver.FindElement(By.Id("Email"));
        public IWebElement PasswordInput => _driver.FindElement(By.Id("Password"));
        public IWebElement EmailValidationMessage => _driver.FindElement(By.CssSelector("span.field-validation-valid[data-valmsg-for='Email']"));
        public IWebElement RememberMeCheckbox => _driver.FindElement(By.Id("RememberMe"));
        public IWebElement ForgotPasswordLink => _driver.FindElement(By.CssSelector("a[href='/passwordrecovery']"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("input.button-1.login-button"));
        public IWebElement RegisterLink => _driver.FindElement(By.CssSelector("a[href='/register'].ico-register"));
        public IWebElement LoginLink => _driver.FindElement(By.CssSelector("a[href='/login'].ico-login"));
        public IWebElement ShoppingCartCount => _driver.FindElement(By.CssSelector("div.mini-shopping-cart > div.count"));
        public IWebElement WishlistLabel => _driver.FindElement(By.CssSelector("span.cart-label"));
        public IWebElement UserEmailLink => _driver.FindElement(By.CssSelector("a.account"));
        public IWebElement LogoutLink => _driver.FindElement(By.CssSelector("a[href='/logout'].ico-logout"));

        public void EnterUserName(string email)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }


        public string GetEmailValidationMessage()
        {
            return EmailValidationMessage.Text.Trim();
        }

        public void CheckRememberMe()
        {
            if (!RememberMeCheckbox.Selected)
            {
                RememberMeCheckbox.Click();
            }
        }

        public void UncheckRememberMe()
        {
            if (RememberMeCheckbox.Selected)
            {
                RememberMeCheckbox.Click();
            }
        }

        public void ClickForgotPasswordLink()
        {
            ForgotPasswordLink.Click();
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickLogoutLink()
        {
            LogoutLink.Click();
        }


        public void ClickRegisterLink()
        {
            RegisterLink.Click();
        }

        public void ClickLoginLink()
        {
            LoginLink.Click();
        }

        public string GetShoppingCartItemCount()
        {
            return ShoppingCartCount.Text.Trim();
        }

        public void ClickWishlist()
        {
            WishlistLabel.Click();
        }

        public bool IsUserEmailDisplayed(string userEmail)
        {
            return UserEmailLink.Text.Trim().Equals(userEmail);
        }
    }
}
