using AventStack.ExtentReports;
using FinalTest.ActionKeywords;
using FinalTest.Reports;
using FluentAssertions;
using FluentAssertions.AssertMultiple;
using OpenQA.Selenium;
using System;

namespace FinalTest.Pages
{
    public class CheckOutCompletePage : BasePage
    {
        /// <summary>
        /// Constructor of the Check out complete page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public CheckOutCompletePage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        public string actualURL = "https://www.saucedemo.com/checkout-complete.html";
        public IWebElement ActualHeader => driver.FindElement(By.XPath("//h2[contains(@class,'complete-header')]"));
        public IWebElement ActualDes => driver.FindElement(By.XPath("//div[contains(@class,'complete-text')]"));
        public IWebElement ActualImg => driver.FindElement(By.XPath("//img[@src='img/pony-express.png']"));

        #endregion

        #region Action Check
        /// <summary>
        /// Use AssertMultiple to compare actual result and expected result
        /// </summary>
        public void CheckExpected(string username)
        {
            string actualDescription = ActualDes.GetAttribute("innerText");
            var test = ExtentReport.BrowserTest("Verify order successfully with " + "'" + username + "'", "ValidateOrderSuccessfully username");
            AssertMultiple.Multiple(() =>
            {
                try
                {
                    actualURL.Should().Be(driver.Url);
                    webKeywords.IsDisplay(ActualHeader).Should().BeTrue();
                    actualDescription.Should().Be("Your order has been dispatched, and will arrive just as " +
                    "fast as the pony can get there!");
                    webKeywords.IsDisplay(ActualImg).Should().BeTrue();
                    test.Log(Status.Pass, "Test Pass");
                    
                }
                catch
                {
                    
                    test.Log(Status.Fail, "Test Fail");
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile(@"..\..\..\Images\CheckOuntComplete" + DateTime.Today + ".png");
                }
            });
        }


    }
    #endregion
}

