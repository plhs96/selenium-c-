using FinalTest.ActionKeywords;
using OpenQA.Selenium;

namespace FinalTest.Pages
{
    public class CheckOutStepTwoPage : BasePage
    {
        /// <summary>
        /// Constructor of the Check out step two page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public CheckOutStepTwoPage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        public string btnFinish = "//a[@href='./checkout-complete.html']";

        #endregion

        #region Element Action
        /// <summary>
        /// Click Finish button
        /// </summary>
        public void ClickFinish()
        {
            webKeywords.WaitClickUI(driver, btnFinish, 20);
        }

        #endregion
    }
}
