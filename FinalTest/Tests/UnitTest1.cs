using Final.Json;
using FinalTest.ActionKeywords;
using FinalTest.Drivers;
using FinalTest.Json;
using FinalTest.Object;
using FinalTest.Pages;
using FinalTest.Reports;
using OpenQA.Selenium;
using System;
using Xunit;

namespace FinalTest
{
    public class UnitTest1 : IClassFixture<TestFixture>, IDisposable
    {
        static string value;
        IWebDriver driver;

        public UnitTest1()
        {
            value = ReadJson.GetDataConfig();
            driver = DriverFactory.GetDriver(value);
            driver.Manage().Window.Maximize();

        }
        /// <summary>
        /// This method is used for validating order succesfully.
        /// It will run end-to-end. 
        /// Begin at login page which allows user input 
        /// valid username, password and login successfully.
        /// Finish at Check out complete page which allows user order successfully.
        /// </summary>
        /// <param name="data"></param>
        [Theory]
        [MemberData(nameof(ReadJson.GetDataForTC1), MemberType = typeof(ReadJson))]
        public void ValidateOrderSuccessfully(DataObject data)
        {
            WebKeywords webKeywords = new WebKeywords(driver);
            LoginPage loginPage = new LoginPage(driver, webKeywords);
            loginPage.Login(data.Username, data.Password);
            InventoryPage inventoryPage = new InventoryPage(driver, webKeywords);
            inventoryPage.AddToCart(data.Product);
            inventoryPage.ClickShoppingCartIcon();
            CartPage cartPage = new CartPage(driver, webKeywords);
            cartPage.ClickCheckOut();
            CheckOutStepOnePage checkOutStepOne = new CheckOutStepOnePage(driver, webKeywords);
            checkOutStepOne.CheckOutInformation(data.FirstName, data.LastName, data.PostalCode);
            CheckOutStepTwoPage checkOutStepTwo = new CheckOutStepTwoPage(driver, webKeywords);
            checkOutStepTwo.ClickFinish();
            CheckOutCompletePage checkOutCompletePage = new CheckOutCompletePage(driver, webKeywords);
            checkOutCompletePage.CheckExpected(data.Username);
        }

        /// <summary>
        /// This method is used for validating login fail case
        /// </summary>
        /// <param name="data"></param>
        [Theory]
        [MemberData(nameof(ReadJson.GetDataForTC2), MemberType = typeof(ReadJson))]
        public void ValidateNegativeLogin(DataObject data)
        {
            ExtentReport.ExtentStart();
            WebKeywords webKeywords = new WebKeywords(driver);
            LoginPage loginPage = new LoginPage(driver, webKeywords);
            loginPage.Login(data.Username, data.Password);
            loginPage.CheckExpected();

        }

        /// <summary>
        /// This method is used for validating images on inventory page are display
        /// or not when user login with username problem_user
        /// </summary>
        /// <param name="data"></param>
        [Theory]
        [MemberData(nameof(ReadJson.GetDataForTC3), MemberType = typeof(ReadJson))]
        public void ValidateDisplayImg(DataObject data)
        {
            WebKeywords webKeywords = new WebKeywords(driver);
            LoginPage loginPage = new LoginPage(driver, webKeywords);
            loginPage.Login(data.Username, data.Password);
            InventoryPage inventoryPage = new InventoryPage(driver, webKeywords);
            inventoryPage.CheckExpected();
        }

        /// <summary>
        /// Quit browser and clear session
        /// </summary>
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
