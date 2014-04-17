using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
   public class AutoLoginDatamover
    {
        [Test]
        public void Login()
        {

            var webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("http://datamover.azaas.com/");
            while (webDriver.Url != "http://datamover.azaas.com/Home/Index")
            {
                var userName = webDriver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("edison@azaas.com");

                webDriver.FindElement(By.CssSelector("input#Password")).SendKeys("123456");
                webDriver.FindElement(By.CssSelector("input#ValidateCode")).SendKeys(CodeServiceClient.CodeService.GetCode());
                webDriver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }

            //登陆成功！
            Assert.AreEqual(webDriver.FindElement(By.LinkText("Logout")).GetAttribute("class"), "outBtn");

        }
    }
}
