using System;

namespace FinalTest.Reports
{
    public class TestFixture : IDisposable
    {
        public void Dispose()
        {
            ExtentReport.ExtentClose();
        }
    }
}
