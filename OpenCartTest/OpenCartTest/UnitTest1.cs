using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace OpenCartTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(ConstantsOpenCart.MAIN_PAGE_OPEN_CART);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void Test_add_products_to_cart_first_type()
        {
            // Steps                       
            driver.FindElement(By.XPath("//div[2]/div[1]/div/div[3]/button[1]")).Click();
            driver.FindElement(By.XPath("//ul/li[4]/a/i")).Click();
            IWebElement actual = driver.FindElement(By.LinkText("MacBook"));

            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }

        [Test]
        public void Test_add_products_to_cart_second_type()
        {
            // Steps                       
            driver.FindElement(By.XPath("//a[text() = 'MacBook']")).Click();//Find element 'MacBook'
            driver.FindElement(By.cssSelector(".btn.btn-primary.btn-lg.btn-block")).Click();
            driver.FindElement(By.cssSelector("//span[text() = 'Shopping Cart']")).Click(); 
            IWebElement actual = driver.FindElement(By.LinkText("MacBook"));

            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }

        [Test]
        public void Test_delete_product_from_cart()
        {
            // Steps          
            driver.FindElement(By.XPath("//div[2]/div[1]/div/div[3]/button[1]")).Click();
            driver.FindElement(By.XPath("//ul/li[4]/a/i")).Click();
            driver.FindElement(By.LinkText("MacBook"));
            driver.FindElement(By.XPath("//form/div/table/tbody/tr/td[4]/div/span/button[2]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(10));
            IWebElement actual1 = driver.FindElement(By.LinkText("Continue"));

            //assert 
            Assert.True(actual1.Displayed);
        }
    }
}
