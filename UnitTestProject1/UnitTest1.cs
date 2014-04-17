using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [Test]
        public void Test2()
        {
            //var driver = new InternetExplorerDriver(@"D:\test file\selenium\IEDriverServer");
           //FirefoxProfile firfoxProfile = new FirefoxProfile(@"D:\install\Mozilla Firefox");
            
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://tourism.51book.com/adminLogin.htm");
            driver.FindElement(By.Id("userName")).SendKeys("ZLBGYCS");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("submit")).Submit();
            driver.FindElement(By.XPath("/html/body/table/tbody/tr/td[1]/div/a[1]")).Click();
            System.Collections.Generic.IList<string> handls=driver.WindowHandles;
            IWebDriver childeDriver = driver.SwitchTo().Window(handls[1]);
            
            childeDriver.FindElement(By.Id("nextSteps")).Click();

            //////childeDriver.SwitchTo().DefaultContent();
            //////childeDriver.SwitchTo().Frame(1);
            var iframe = childeDriver.FindElement(By.CssSelector("iframe.ke-edit-iframe"));
            childeDriver.SwitchTo().Frame(iframe);//进入iframe
            childeDriver.FindElement(By.XPath("/html/body")).SendKeys("12345678");//进入body输入数据

           
        }

        [Test]
        public void Test3()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.baidu.com");
            //driver.FindElement(By.LinkText("登录")).Click();
            driver.FindElementById("lb").Click();

        }
    }
}
