using FinalTest.ActionKeywords;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTest.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public WebKeywords webKeywords;
    }
}
