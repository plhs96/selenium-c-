using FinalTest.ActionKeywords;
using OpenQA.Selenium;

namespace FinalTest.Pages
{
    public class CartPage : BasePage
    {
        /// <summary>
        /// Constructor of the CartPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public CartPage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        public string btnCheckOut = "//a[@href='./checkout-step-one.html']";

        #endregion

        #region Element Action
        /// <summary>
        /// Click Check Out button
        /// </summary>
        public void ClickCheckOut()
        {
            webKeywords.WaitClickUI(driver, btnCheckOut, 20);
        }

        #endregion
    }
}
