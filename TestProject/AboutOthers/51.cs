using log4net.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.IO;
using TestProject.About51;


namespace TestProject
{
    class _51
    {

        [Test]
        public void Test()
        {
            string testTime = DateTime.Now.ToString("t");

            var driver=new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.51aqy.com/");
            driver.FindElement(By.CssSelector("a.xs2-link")).Click();
            System.Collections.Generic.IList<string> handles = driver.WindowHandles;//获取窗口数量
            IWebDriver chilWindow = driver.SwitchTo().Window(handles[1]);//调转到当前窗口
           // chilWindow.Close();//关闭当前窗口

            chilWindow.FindElement(By.CssSelector("a.app-data > span.text")).Click();//对当前窗口操作
            System.Collections.Generic.IList<string> handles1 = chilWindow.WindowHandles;
            IWebDriver TwoWindow = chilWindow.SwitchTo().Window(handles1[1]);
            TwoWindow.FindElement(By.Id("input1")).SendKeys("880082993370");
            TwoWindow.FindElement(By.Id("input2")).SendKeys("15015015050");
            TwoWindow.FindElement(By.CssSelector("button.open-client")).Click();
            TwoWindow.FindElement(By.CssSelector("#myModal-no-bangding > div.modal-header > button.close")).Click();
            string actualResult = TwoWindow.FindElement(By.CssSelector("div.info > span.info-name ")).Text;
            string expectedResult = "尊敬的用户";
            Assert.AreEqual(expectedResult, actualResult);

            //Console.WriteLine(actualResult);
            //将测试结果写入excel

            // Helper.NPOIHelper(testTime,expectedResult,actualResult);
            log4net.ILog iLog = log4net.LogManager.GetLogger("message");
            if (iLog.IsDebugEnabled)
            {
                iLog.Debug("debug");
            }
            if (iLog.IsInfoEnabled)
            {
                iLog.Info("message");
            }

            driver.Quit();
            
        
        
        }
        
    }
}
