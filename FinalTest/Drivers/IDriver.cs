using OpenQA.Selenium;

namespace FinalTest.Drivers
{
    public interface IDriver
    {
        IWebDriver Driver { get; set; }
        IWebDriver StartService();
    }
}
