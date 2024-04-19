namespace Shan.WebAutomationFramework
{
    public class TestStep
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Status { get; set; }
        public TestStep(int id, string name, string status){
            Id = id;
            Name = name;
            Status = status;
        }
    }
}