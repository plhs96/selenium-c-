using FinalTest.ActionKeywords;
using OpenQA.Selenium;

namespace FinalTest.Pages
{
    public class CheckOutStepOnePage : BasePage
    {
        /// <summary>
        /// Constructor of the Check out step one page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public CheckOutStepOnePage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        public string txtFirstname = "//input[@id='first-name']";
        public string txtLastname = "//input[@id='last-name']";
        public string txtPostalCode = "//input[@id='postal-code']";
        public string btnContinue = "//input[@type='submit']";
        #endregion

        #region Element Action
        /// <summary>
        /// Fill in the form by send key firstname, lastname and postcode and then click
        /// Continue button
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        public void CheckOutInformation(string firstName, string lastName, string postCode)
        {
            webKeywords.WaitSendKey(driver, txtFirstname, 20, firstName);
            webKeywords.WaitSendKey(driver, txtLastname, 20, lastName);
            webKeywords.WaitSendKey(driver, txtPostalCode, 20, postCode);
            webKeywords.WaitClickUI(driver, btnContinue, 20);
        }

        #endregion
    }
}
