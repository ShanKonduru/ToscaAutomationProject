namespace Shan.WebAutomationFramework
{
    public class TestCase(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Status { get; set; }
        public string ExecutionTime { get; set; }
        public List<TestStep> TestSteps = new List<TestStep>();
    }
}