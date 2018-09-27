using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            // Application.Get();
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=common/home");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void Test_add_products_to_cart()
        {
            // Steps                       
            driver.FindElement(By.XPath("//div[2]/div[1]/div/div[3]/button[1]")).Click();
            driver.FindElement(By.XPath("//ul/li[4]/a/i")).Click();
            IWebElement actual = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[2]/a"));

            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }

        [Test]
        public void Test_delete_product_from_cart()
        {
            // Steps          
            driver.FindElement(By.XPath("//div[2]/div[1]/div/div[3]/button[1]")).Click();
            driver.FindElement(By.XPath("//ul/li[4]/a/i")).Click();
            driver.FindElement(By.XPath("//form/div/table/tbody/tr/td[4]/div/span/button[2]")).Click();
            //IWebDriver actual = driver.FindElement(By.XPath("//a[contains(@href,'http://atqc-shop.epizy.com/index.php?route=common/home')]"));

            //assert
            //Assert.AreEqual("Continue!", actual.Text);
        }
    }
}