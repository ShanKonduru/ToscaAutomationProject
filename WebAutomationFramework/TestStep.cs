namespace Shan.WebAutomationFramework
{
    public class TestStep(int id, string name, string status)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Status { get; set; } = status;
        public string ScreenshotPath { get; set; }

        public TestStep(int id, string name, string status, string screenshotPath) : this(id, name, status){
            ScreenshotPath = screenshotPath;
        }
    }
}