namespace Shan.WebAutomationFramework
{
    public class TestStep(int id, string name, string status, string screenshotPath)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Status { get; set; } = status;
        public string ScreenshotPath { get; set; } = screenshotPath;
    }
}