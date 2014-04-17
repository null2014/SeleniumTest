using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject.Help;

namespace TestProject
{
    class WaitFunTest
    {

        [Test]
        public void DriverExtension_Wait()
        {
            var driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.FindElement(By.Id("kw")).SendKeys("selenium");
            driver.FindElement(By.Id("su")).Submit();
            driver.WaitTitleContains("selenium");
            Assert.True(driver.Title.Contains("selenium"));


            driver.Navigate().GoToUrl("http://docs.seleniumhq.org/docs/03_webdriver.jsp");
            driver.WaitElementExist(By.Id("additional-resources"));
            var ele = driver.FindElement(By.Id("additional-resources"));//接收这个元素，类似于判断


            driver.Navigate().GoToUrl("https://www.mozilla.org/en-US/about/");
            driver.WaitUnit<bool>(
              p => p.FindElement(By.Id("masthead")).Text == "Mozilla");

        }

        [Test]
        public void DriverExtension_ExeJavascript()
        {
            var driver = Helper.WebDriverInstance;
            driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.ExecJavascript("document.getEelementById('kw').value='selenium'");
            driver.ExecJavascript("document.getEelementById('su').Click()");
            Assert.True(driver.Title.Contains("selenium"));
            
            }

    }
}
