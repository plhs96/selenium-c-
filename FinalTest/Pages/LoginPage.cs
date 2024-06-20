using FinalTest.ActionKeywords;
using FluentAssertions;
using FluentAssertions.AssertMultiple;
using OpenQA.Selenium;

namespace FinalTest.Pages
{
    public class LoginPage : BasePage
    {
        /// <summary>
        /// Constructor of LoginPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public LoginPage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        public string txtUsername = "//input[@id='user-name']";
        public string txtPassword = "//input[@id='password']";
        public string btnLogin = "//input[@id='login-button']";
        public IWebElement ActualMsg => driver.FindElement(By.XPath("//h3"));
        #endregion

        #region Element Action
        /// <summary>
        /// Perform the action Login. User can send key username, password and click
        /// to login button.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            webKeywords.Navigate("https://www.saucedemo.com/");
            webKeywords.WaitSendKey(driver, txtUsername, 20, username);
            webKeywords.WaitSendKey(driver, txtPassword, 20, password);
            webKeywords.WaitClickUI(driver, btnLogin, 20);
        }

        #endregion

        #region Action Check
        /// <summary>
        /// Use AssertMultiple to compare actual result and expected result
        /// </summary>
        public void CheckExpected()
        {
            string actualH3 = ActualMsg.GetAttribute("innerText");
            AssertMultiple.Multiple(() =>
            {

                actualH3.Should().Be("Epic sadface: Sorry, this user has been locked out.");
            });
        }
        #endregion
    }
}
