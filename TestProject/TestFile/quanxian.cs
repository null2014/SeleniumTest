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
    public class Quanxian
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
        public void TheQuanxianTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Files/Index");
            driver.FindElement(By.XPath("//ul[@id='commandList']/li[2]/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td")).Click();
            driver.FindElement(By.XPath("(//input[@value='设置权限'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[27]")).Click();
            driver.FindElement(By.CssSelector("#window_contact > div.BorderWidth > div.boxfooter > table.table-fpw_operation > tbody > tr > td > a.btn_ok")).Click();
            driver.FindElement(By.XPath("(//input[@name='AutRadio'])[9]")).Click();
            driver.FindElement(By.CssSelector("#window_Permissions > div.BorderWidth > div.boxfooter > table.table-fpw_operation > tbody > tr > td > a.btn_ok")).Click();
            driver.FindElement(By.CssSelector("#window_addShare > div.BorderWidth > div.boxfooter > table.table-fpw_operation > tbody > tr > td > a.btn_ok")).Click();
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
