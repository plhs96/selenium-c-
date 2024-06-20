using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FinalTest.Drivers
{
    public class Chrome : IDriver
    {
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Start service to open chrome browser
        /// </summary>
        /// <returns></returns>
        public IWebDriver StartService()
        {
            Driver = new ChromeDriver(Environment.CurrentDirectory);
            return Driver;
        }
    }
}
