using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Selenium;
using TestProject.Help;
using Helper = TestProject.About51.Helper;


namespace TestProject.DMAutoTest
{
    internal class Upload
    {
        private ISelenium selenium;
        
        [Test]
        public void UploadSuccessful()
        {

            string url = "http://testpan.chinacloudapp.cn/";
            string userName = "cman";
            string Password = "1";
            var driver = Helper.DMLogin(url, userName, Password);
            driver.FindElement(By.CssSelector("a.menuBtn_upload > span.icontxt")).Click();
            driver.FindElement(By.CssSelector("a.a-pw_add > span.icontxt")).Click();

            //使用autoit操作windows窗口
            Helper.AutoitHelper(@"D:\temp\test.xls");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("upload-done")).Click();
            Thread.Sleep(2000);

            //找到上传的文件，删除，测试通过
            var ExistTableElement =
                driver.FindElement(
                    By.CssSelector("table[data-name='test.xls']"));

            var mouseOverAction = new OpenQA.Selenium.Interactions.Actions(driver);
            mouseOverAction.MoveToElement(ExistTableElement);
            mouseOverAction.Perform();
            ExistTableElement.FindElement(By.CssSelector("div.menuBtn > a.delete")).Click();
            driver.FindElement(By.XPath("//*[@id='window_delete']/div/div[3]/table/tbody/tr/td[1]/a")).Click();


            driver.Quit();

        }

        [Test]
        public void UploadTestWithOther()
        {

            //DesiredCapabilities aDesirdecap = DesiredCapabilities.InternetExplorer();
            //aDesirdecap.SetCapability(CapabilityType.Version, "8");
            //aDesirdecap.SetCapability("", "");
            //aDesirdecap.SetCapability("", "");
             

        }

        public class DMRemoteDriver : RemoteWebDriver
        {
            public DMRemoteDriver(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities)
                : base(commandExecutor, desiredCapabilities) 
            {
            }

            public DMRemoteDriver(ICapabilities desiredCapabilities)
                : base(new Uri("http://hub.testingbot.com:4444/wd/hub"), desiredCapabilities)
            {
            }

            public DMRemoteDriver(Uri remoteAddress, ICapabilities desiredCapabilities)
                : base(remoteAddress, desiredCapabilities, TimeSpan.FromSeconds(400))
            {
            }

            public String getSessionId()
        
        {
            return this.SessionId.ToString();
        }

        }
    }
}
