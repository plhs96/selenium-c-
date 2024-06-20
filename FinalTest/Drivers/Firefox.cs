using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace FinalTest.Drivers
{
    public class Firefox : IDriver
    {
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Start service to open firefox browser
        /// </summary>
        /// <returns></returns>
        public IWebDriver StartService()
        {
            Driver = new FirefoxDriver(Environment.CurrentDirectory);
            return Driver;
        }
    }
}
