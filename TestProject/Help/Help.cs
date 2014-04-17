using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestProject.Help
{

    public class Helper
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private IWebElement webTable;



        //public void LoginHelp()
        //{

        // driver.Navigate().GoToUrl(baseURL);

        //    ITimeouts timeouts = driver.Manage().Timeouts();
        //         while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
        //    {
        //        var userName = driver.FindElement(By.CssSelector("input#UserName"));
        //        userName.Clear();
        //        userName.SendKeys("cman@azaas.com");
        //        driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
        //        driver.FindElement(By.CssSelector("input#ValidateCode")).SendKeys(CodeServiceClient.CodeService.GetCode());
        //        driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
        //         }
        //}

        public static IWebDriver WebDriverInstance
        {
            get
            {
                return new FirefoxDriver();

            }

        }

        public static void RunProgram(string programName, string args = "")
        {
            var p = string.IsNullOrWhiteSpace(args)
                ? Process.Start(programName)
                : Process.Start(programName, args);
            p.WaitForExit();
        }
    }

    public static class DriverExtensions
    {

        public static void WaitUnit<T>(this IWebDriver webDriver, Func<IWebDriver, T> func, int seconds = 20)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(func); //这里func可以写一个function？？
        }

        public static void WaitElementExist(this IWebDriver webDriver, By by, int seconds = 20)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementExists(by)); //by为某个存在的元素的定位方式 eg:By.Xpath("")
        }

        public static void WaitElementVisible(this IWebDriver webDriver, By by, int seconds = 20)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(""))); //css中某个元素visibility属性为visible的定位，
            //但是这个方式没有IJavaScriptExecutor稳定性强
        }

        public static void WaitTitleContains(this IWebDriver webDriver, string title, int seconds = 20)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.TitleContains(title)); //title应该为标题包含的内容
        }

        public static void WaitTitles(this IWebDriver webDriver, string title, int senconds = 20)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(senconds));
            wait.Until(ExpectedConditions.TitleIs(title)); //title和浏览器当前的一致
        }

        public static void ExecJavascript(this IWebDriver webDriver, string jsCode)
        {
            ((IJavaScriptExecutor) webDriver).ExecuteScript(jsCode); //强制执行
        }

        public class TestJDBCDriver
        {

            private String username;

            private String password;

            public TestJDBCDriver(String username, String password)
            {

                this.username = username;

                this.password = password;

            }

        }
        


    }
}
