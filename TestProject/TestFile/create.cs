using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Create
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://testpan.chinacloudapp.cn/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCreateTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Files/Index");
            driver.FindElement(By.CssSelector("a.menuBtn_create > span.icontxt")).Click();
            driver.FindElement(By.CssSelector("input.txt-fileName")).Clear();
            driver.FindElement(By.CssSelector("input.txt-fileName")).SendKeys("8989");
            driver.FindElement(By.CssSelector("div.fileCommand > span.MixiTai_Checkbox")).Click();
            driver.FindElement(By.CssSelector("a.delete > input[type=\"button\"]")).Click();
            driver.FindElement(By.CssSelector("#window_delete > div.BorderWidth > div.boxfooter > table.table-fpw_operation > tbody > tr > td > a.btn_ok")).Click();
            driver.FindElement(By.CssSelector("table.table-btn > tbody > tr > td > a.btn_ok")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
