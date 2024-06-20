using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace FinalTest.Reports
{
    public static class ExtentReport
    {
        public static ExtentTest test;
        public static ExtentReports extent = new ExtentReports();
        public static void ExtentStart()
        {
            var htmlreporter = new ExtentHtmlReporter(@"..\..\..\Reports\Report.html");
            extent.AttachReporter(htmlreporter);
        }

        public static ExtentTest BrowserTest(string moduleName, string testcaseName)
        {
            ExtentStart();
            return extent.CreateTest(testcaseName).Info(moduleName);
        }

        public static void ExtentClose()
        {
            extent.Flush();
        }

    }
}
