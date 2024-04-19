using System;
using System.IO;
using OpenQA.Selenium;

namespace Shan.WebAutomationFramework
{
    public static class Utility
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                // Capture screenshot
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Define the screenshot file path
                string fileNameBase = $"{testName}_{DateTime.Now:yyyyMMddHHmmss}";
                string directoryPath = $"{Consts.ExecutionReportBasePath}/Screenshots";
                Directory.CreateDirectory(directoryPath);  // Create directory if it doesn't exist
                string filePath = $"{directoryPath}\\{fileNameBase}.jpeg";

                // Save the screenshot
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                throw;
            }
        }
    }
}
