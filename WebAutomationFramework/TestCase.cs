namespace Shan.WebAutomationFramework
{
    public class TestCase
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Status { get; set; }
        public  string ExecutionTime { get; set; }
        public List<TestStep> TestSteps = new List<TestStep>();

        public TestCase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddTestStatus(string status){
            Status = status;
        }

        public void AddTestExecutionTime(string executionTime)
        {
            ExecutionTime = executionTime;
        }

        public void AddTestStep(TestStep testStep)
        {
            TestSteps.Add(testStep);
        }
    }
}