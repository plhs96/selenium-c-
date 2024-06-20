using FinalTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FinalTest.ActionKeywords
{
    public class WebKeywords : BasePage
    {
        /// <summary>
        /// Constructor of the WebKeywords
        /// </summary>
        /// <param name="driver"></param>
        public WebKeywords(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Navigate to the specific url 
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {

            if (!(url.StartsWith("http://") || url.StartsWith("https://")))
                throw new Exception("URL is invalid format and cannot open page");
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Wait until find out the xpath and then click it
        /// </summary>
        /// <param name="xdriver"></param>
        /// <param name="xpathSTR"></param>
        /// <param name="xtime"></param>
        public void WaitClickUI(IWebDriver xdriver, string xpathSTR, double xtime)
        {
            int count = 0;
            bool flag = false;
            while (flag == false && count < 3)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(xtime));
                try
                {
                    //IWebElement xElement = xdriver.FindElement(By.XPath(xpathSTR));
                    IWebElement xElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathSTR)));
                    xElement.Click();
                    flag = true;
                    count = 3;
                }
                catch (Exception e)
                {
                    flag = false;
                    count = count + 1;
                    throw e;
                }
            }
        }

        /// <summary>
        /// Wait until find out the xpath and then send key into it
        /// </summary>
        /// <param name="xdriver"></param>
        /// <param name="xpathSTR"></param>
        /// <param name="xtime"></param>
        /// <param name="xvalue"></param>
        public void WaitSendKey(IWebDriver xdriver, string xpathSTR, double xtime, string xvalue)
        {
            int count = 0;
            bool flag = false;
            while (flag == false && count < 3)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(xtime));
                try
                {
                    IWebElement xElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathSTR)));
                    xElement.SendKeys(xvalue);
                    flag = true;
                    count = 3;
                }
                catch (Exception e)
                {
                    flag = false;
                    count = count + 1;
                    throw e;
                }
            }
        }

        /// <summary>
        /// Get actual result and return boolean value
        /// </summary>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public bool IsDisplay(IWebElement actualResult)
        {
            try
            {
                IWebElement result = actualResult;
                return result.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
