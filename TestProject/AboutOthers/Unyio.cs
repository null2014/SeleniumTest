using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject.Help;
using Helper = TestProject.About51.Helper;

namespace TestProject.AboutOthers
{
    class Unyio
    {

        [Test]
        public void UnyioTest()
        {
            var driver = Helper.OpenIEDriver("http://www.uniyo.com/");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("top_IBlogin")).Click();
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("leftFrame");
            driver.FindElement(By.CssSelector("#item_70 > a")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("manFrame");
          

            //直接用js对日期控件进行操作
            var DatePicker = driver.FindElement(By.Id("d15"));
            String sProductDate = "2014-03-06";
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value=arguments[1]", DatePicker, sProductDate);
            //driver.FindElement(By.XPath("//*[@class='WdayTable']/tbody/tr[6]/td[3]")).Click();
        }

        [Test]
        public void JDTest()
        {
            var driver =
                Helper.OpenFireFoxDriver("http://www.jd.com/");



        }
    }
}
