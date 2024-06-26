﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shan.WebAutomationFramework;
using System.Reflection;

/*
// The source code was generated by cSharpSeleniumGenerator.js
// Copyright: Tricentis
// Website: https://www.tricentis.com
// C# plugin version: 1.3.4
*/
namespace tricentis.qtest.demowebshop.test
{
    [TestClass]
    public class TestRegisterUser
    {
        private IWebDriver _driver;
        private const int MOUSE_LEFT = 0;
        private const int MOUSE_RIGHT = 2;
        private const bool alwaysExecuteActionInLatestWindow = true;

        private int testCaseId = 1;

        private static TestExecutionReport _executionReport = new TestExecutionReport();
        private static string ReportFilePath = String.Format($"{Consts.ExecutionReportBasePath}/TestAutomationReport-{DateTime.Now.ToString("yyyyMMddhhmmss")}.html");
        public TestContext? TestContext { get; set; }  // Declare TestContext as nullable

        [TestInitialize]
        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/login");
        }

        [TestMethod]
        public void TestRegisterNewUserScenario()
        {
            var testcaseName = TestContext.TestName;
            var testCase = new TestCase(testCaseId++, testcaseName);

            try
            {
                TimeTracker.Start(testcaseName);
                // Add test case and test steps to execution report
                var homePage = new HomePage(_driver);
                var registerPage = new RegisterPage(_driver);

                // Generate random user details
                var random = new Random();
                var firstName = $"User{random.Next(1000, 9999)}";
                var lastName = $"One{random.Next(1000, 9999)}";
                var email = $"{firstName}@example.com";
                var password = "Password123";

                var teststep = 1;
                homePage.ClickRegisterLink();
                testCase.TestSteps.Add(new TestStep(teststep++, "click Register Link", "Passed"));

                registerPage.SelectGender("male");
                testCase.TestSteps.Add(new TestStep(teststep++, "click SelectGender", "Passed"));

                registerPage.EnterFirstName(firstName);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter First Name", "Passed"));

                registerPage.EnterLastName(lastName);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Last Name", "Passed"));

                registerPage.EnterEmail(email);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Email ID", "Passed"));

                registerPage.EnterPassword(password);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Password", "Passed"));

                registerPage.ConfirmPassword(password);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Confirm Password", "Passed"));

                registerPage.ClickRegisterButton();
                testCase.TestSteps.Add(new TestStep(teststep++, "Click Register Button", "Passed"));

                registerPage.ClickContinueButton();
                testCase.TestSteps.Add(new TestStep(teststep++, "Click Continue Button", "Passed", Utility.CaptureScreenshot(_driver, testcaseName)));

                var milliseconds = TimeTracker.Stop(testcaseName);
                testCase.Status = "Passed";
                testCase.ExecutionTime = TimeTracker.GetElapsedTime(milliseconds);

                _executionReport.AddTestCase(testCase);
            }
            catch (Exception ex)
            {
                testCase.Status = (string.Format("Failed, Reason: {0} Inner Exception: {1}", ex.Message, ex.InnerException?.Message ?? "None"));
            }
        }

        [TestMethod]
        public void TestRegisterExistingUserScenario()
        {
            var testcaseName = TestContext.TestName;
            var testCase = new TestCase(testCaseId++, testcaseName);

            try
            {
                TimeTracker.Start(testcaseName);

                var homePage = new HomePage(_driver);
                var registerPage = new RegisterPage(_driver);

                var teststep = 1;
                homePage.ClickRegisterLink();
                testCase.TestSteps.Add(new TestStep(teststep++, "click Register Link", "Passed"));

                registerPage.SelectGender("male");
                testCase.TestSteps.Add(new TestStep(teststep++, "click Gender Male", "Passed"));

                registerPage.EnterFirstName("User");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter First Name", "Passed"));

                registerPage.EnterLastName("One");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Last Name", "Passed"));

                registerPage.EnterEmail("UserOne@UserOne.com");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Email ID", "Passed"));

                registerPage.EnterPassword("UserOne");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Password", "Passed"));

                registerPage.ConfirmPassword("UserOne");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Confirm Password", "Passed"));

                registerPage.ClickRegisterButton();
                testCase.TestSteps.Add(new TestStep(teststep++, "Click Register Button", "Passed"));

                bool IsErrorMessageDisplayed = registerPage.IsErrorMessageDisplayed("The specified email already exists"); 
                Assert.IsTrue(IsErrorMessageDisplayed, "Error message not displayed, meaning this user is not existing in the system.");
                if (IsErrorMessageDisplayed)
                {
                    testCase.TestSteps.Add(new TestStep(teststep++, "Validate The specified email already existsss", "Passed", Utility.CaptureScreenshot(_driver, testcaseName)));
                }
                else
                {
                    testCase.TestSteps.Add(new TestStep(teststep++, "Error message not displayed, meaning this user is not existing in the system.", "Failed", Utility.CaptureScreenshot(_driver, testcaseName)));
                }

                var milliseconds = TimeTracker.Stop(testcaseName);
                testCase.Status = "Passed";
                testCase.ExecutionTime = TimeTracker.GetElapsedTime(milliseconds);

                _executionReport.AddTestCase(testCase);
            }
            catch (Exception ex)
            {
                testCase.Status = string.Format("Failed, Reason: {0} Inner Exception: {1}", ex.Message, ex.InnerException?.Message ?? "None");
            }
        }

        [TestMethod]
        public void TestUserLoginScenario()
        {
            var testcaseName = TestContext.TestName;
            var testCase = new TestCase(testCaseId++, testcaseName);

            try
            {
                TimeTracker.Start(testcaseName);

                var homePage = new HomePage(_driver);
                string userEmail = "UserOne@UserOne.com";
                var teststep = 1;
                homePage.ClickLoginLink();
                testCase.TestSteps.Add(new TestStep(teststep++, "click Login Link", "Passed"));

                homePage.EnterUserName(userEmail);
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter User Name", "Passed"));

                homePage.EnterPassword("UserOne");
                testCase.TestSteps.Add(new TestStep(teststep++, "Enter Password", "Passed"));

                homePage.ClickLoginButton();
                testCase.TestSteps.Add(new TestStep(teststep++, "Click Log in Button", "Passed"));

                bool userEmailDisplayed = homePage.IsUserEmailDisplayed("UserOne@UserOne.com");
                Assert.IsTrue(userEmailDisplayed, $"User email '{userEmail}' is not displayed on the home page.");
                if (userEmailDisplayed)
                {
                    testCase.TestSteps.Add(new TestStep(teststep++, "Click Log in Button", "Passed", Utility.CaptureScreenshot(_driver, testcaseName)));
                }
                else
                {
                    testCase.TestSteps.Add(new TestStep(teststep++, "Click Log in Button", "Failed", Utility.CaptureScreenshot(_driver, testcaseName)));
                }

                homePage.ClickLogoutLink();
                testCase.TestSteps.Add(new TestStep(teststep++, "Click Logout Lick", "Passed", Utility.CaptureScreenshot(_driver, testcaseName)));


                var milliseconds = TimeTracker.Stop(testcaseName);
                testCase.Status = "Passed";
                testCase.ExecutionTime = TimeTracker.GetElapsedTime(milliseconds);

                _executionReport.AddTestCase(testCase);
            }
            catch (Exception ex)
            {
                testCase.Status = string.Format("Failed, Reason: {0} Inner Exception: {1}", ex.Message, ex.InnerException?.Message ?? "None");
            }
        }


        [TestCleanup]
        public void TestCleanup()
        {
            string filePath = "";
            try
            {
                // Capture screenshot
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

                // Define the screenshot file path
                string fileNameBase = $"{TestContext.TestName}_{DateTime.Now:yyyyMMddHHmmss}";
                string directoryPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Screenshots";
                Directory.CreateDirectory(directoryPath);  // Create directory if it doesn't exist
                filePath = $"{directoryPath}\\{fileNameBase}.jpeg";

                // Save the screenshot
                screenshot.SaveAsFile(filePath);
                TestContext.WriteLine(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Screenshot saved at: {filePath}");
                _driver.Close();
                _driver.Quit();

                // Generate and save report
                string htmlReport = _executionReport.GenerateReport();
                File.WriteAllText(ReportFilePath, htmlReport);
            }
        }
    }
}
