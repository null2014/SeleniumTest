using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumTests
{
    [TestFixture]
    public class Upload1
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
        public void TheUpload1Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/Account/LogOn?ReturnUrl=%2fHome%2fIndex");
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0,0,50));
            //driver.FindElement(By.Id("UserName")).Clear();
            //driver.FindElement(By.Id("UserName")).SendKeys("cman@azaas.com");
            //driver.FindElement(By.Id("Password")).Clear();
            //driver.FindElement(By.Id("Password")).SendKeys("111111");
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("angkor");

                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode")).SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }
            //driver.FindElement(By.Id("ValidateCode")).Clear();
            //driver.FindElement(By.Id("ValidateCode")).SendKeys("");

            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 30));
            driver.FindElement(By.Id("RememberMe")).Click();
            driver.FindElement(By.Id("login_button_credentials")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 30));

            driver.FindElement(By.CssSelector("li.li-header_files > a > img")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 50));

            driver.FindElement(By.XPath("//ul[@id='commandList']/li[2]/table/tbody/tr/td")).Click();
            driver.FindElement(By.XPath("(//input[@value='打开'])[2]")).Click();
            driver.FindElement(By.CssSelector("a.menuBtn_upload > span")).Click();
            driver.FindElement(By.CssSelector("#a-pw_add > span.icontxt")).Click();
            driver.FindElement(By.Id("fileToUpload")).Clear();
            driver.FindElement(By.Id("fileToUpload")).SendKeys("C:\\Users\\liu\\Pictures\\77.html");
            driver.FindElement(By.LinkText("上传")).Click();
            driver.FindElement(By.LinkText("退出")).Click();
            driver.FindElement(By.XPath("//ul[@id='commandList']/li[2]/table/tbody/tr/td/div/span")).Click();
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
