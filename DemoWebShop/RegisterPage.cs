
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
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickRegisterLink()
        {
            var registerButton = FindElement(By.CssSelector("a[href='/register'].ico-register"));
            registerButton.Click();
        }

        public void SelectGender(string gender)
        {
            var genderRadioButton = FindElement(By.Id($"gender-{gender}"));
            genderRadioButton.Click();
        }

        public void EnterFirstName(string firstName)
        {
            var firstNameField = FindElement(By.Id("FirstName"));
            firstNameField.Clear();
            firstNameField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            var lastNameField = FindElement(By.Id("LastName"));
            lastNameField.Clear();
            lastNameField.SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            var emailField = FindElement(By.Id("Email"));
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            var passwordField = FindElement(By.Id("Password"));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ConfirmPassword(string confirmPassword)
        {
            var confirmPasswordField = FindElement(By.Id("ConfirmPassword"));
            confirmPasswordField.Clear();
            confirmPasswordField.SendKeys(confirmPassword);
        }

        public void ClickRegisterButton()
        {
            var registerButton = FindElement(By.Id("register-button"));
            registerButton.Click();
        }

        public void ClickContinueButton()
        {
            var continueButton = FindElement(By.CssSelector("input.button-1.register-continue-button"));
            continueButton.Click();
        }

        public bool IsErrorMessageDisplayed(string errorMessage)
        {
            try
            {
                var errorElement = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//li[text()='{errorMessage}']")));
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
