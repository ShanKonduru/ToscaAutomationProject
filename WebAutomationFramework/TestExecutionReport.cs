using System.Text;

namespace Shan.WebAutomationFramework
{
    public class TestExecutionReport
    {
        private List<TestCase> testCases = new List<TestCase>();

        public void AddTestCase(TestCase testCase)
        {
            testCases.Add(testCase);
        }

        public string GenerateReport()
        {
            StringBuilder htmlContent = new StringBuilder();

            // Add HTML header
            htmlContent.Append("<!DOCTYPE html>");
            htmlContent.Append("<html lang=\"en\">");
            htmlContent.Append("<head>");
            htmlContent.Append("<meta charset=\"UTF-8\">");
            htmlContent.Append("<title>Test Automation Execution Report</title>");
            htmlContent.Append("<style>");
            htmlContent.Append("table {width: 100%; border-collapse: collapse;}");
            htmlContent.Append("th, td {border: 1px solid black; padding: 8px; text-align: left;}");
            htmlContent.Append("th {background-color: #f2f2f2;}");
            htmlContent.Append("</style>");
            htmlContent.Append("</head>");
            htmlContent.Append("<body>");

            // Add Execution Summary
            htmlContent.Append("<h2>Execution Summary</h2>");
            htmlContent.Append("<table>");
            htmlContent.Append("<tr><th>Test Case</th><th>Status</th><th>Execution Time</th></tr>");

            foreach (var testCase in testCases)
            {
                htmlContent.Append($"<tr><td><a href=\"#{testCase.Id}\">{testCase.Name}</a></td><td>{testCase.Status}</td><td>{testCase.ExecutionTime}</td></tr>");
            }

            htmlContent.Append("</table>");

            // Add Test Case Details
            foreach (var testCase in testCases)
            {
                htmlContent.Append($"<h2 id=\"{testCase.Id}\">{testCase.Name} - {testCase.Status}</h2>");
                htmlContent.Append("<h3>Test Steps</h3>");
                htmlContent.Append("<table>");
                htmlContent.Append("<tr><th>Step Name</th><th>Status</th></tr>");

                foreach (var testStep in testCase.TestSteps)
                {
                    htmlContent.Append($"<tr><td>{testStep.Name}</td><td>{testStep.Status}</td></tr>");
                }

                htmlContent.Append("</table>");
            }

            htmlContent.Append("</body>");
            htmlContent.Append("</html>");

            return htmlContent.ToString();
        }
    }
}