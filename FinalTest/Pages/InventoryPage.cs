using AventStack.ExtentReports;
using FinalTest.ActionKeywords;
using FinalTest.Reports;
using FluentAssertions;
using OpenQA.Selenium;
using System;

namespace FinalTest.Pages
{
    public class InventoryPage : BasePage
    {
        /// <summary>
        /// Constructor for InventoryPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webKeywords"></param>
        public InventoryPage(IWebDriver driver, WebKeywords webKeywords)
        {
            this.driver = driver;
            this.webKeywords = webKeywords;
        }

        #region Element Page
        //div[text()='Sauce Labs Backpack']//parent::a//parent::div//parent::div/div/button
        public string btnAddToCart01 = "//div[text()='";
        public string btnAddToCart02 = "']//parent::a//parent::div//parent::div/div/button";
        public string btnShoppingCart = "//div[@id='shopping_cart_container']//a[@href='./cart.html']";
        public IWebElement ActualImg => driver.FindElement(By.XPath("//a[@id='item_4_img_link']//img[contains(@class,'inventory_item_img')]"));
        #endregion

        #region Element Action
        /// <summary>
        /// Click Add To Cart button with a specify product
        /// </summary>
        /// <param name="nameProduct"></param>
        public void AddToCart(string nameProduct)
        {
            string btnAddToCart = btnAddToCart01 + nameProduct + btnAddToCart02;
            var test = ExtentReport.BrowserTest("Verify Login successfully with ", "ValidateLoginSuccessfull");
            try
            {
                webKeywords.WaitClickUI(driver, btnAddToCart, 2);
                test.Log(Status.Pass, "Test Pass");
            }
            catch(Exception e)
            {  
                test.Log(Status.Fail, "Test Fail");
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"..\..\..\Images\Inventory"+DateTime.Today+".png");
                throw e;
            }
            
        }

        /// <summary>
        /// Click Shopping Cart Icon at the top-right corner of the page to navigate
        /// to Cart Page
        /// </summary>
        public void ClickShoppingCartIcon()
        {
            webKeywords.WaitClickUI(driver, btnShoppingCart, 20);
        }

        #endregion

        #region
        /// <summary>
        /// Use AssertMultiple to compare actual result and expected result
        /// </summary>
        public void CheckExpected()
        {
            string actualImg = ActualImg.GetProperty("src");
            var test = ExtentReport.BrowserTest("Verify Image of product successfully with ", "ValidateImageProductSuccessfull");
            try
            {

                actualImg.Should().Be("https://www.saucedemo.com/img/sauce-backpack-1200x1500.jpg");
                test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Test Fail");
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"..\..\..\Images\ImageProd.png");
                throw e;
            }
            //AssertMultiple.Multiple(() =>
            //{
            //    try
            //    {
                    
            //        actualImg.Should().Be("https://www.saucedemo.com/img/sauce-backpack-1200x1500.jpg");
            //        test.Log(Status.Pass, "Test Pass");
            //    }
            //    catch (Exception e)
            //    {
            //        test.Log(Status.Fail, "Test Fail");
            //        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //        ss.SaveAsFile(@"..\..\..\Images\ImageProd.png");
            //        throw e;
            //    }
                
            //});
        }
        #endregion
    }
}
