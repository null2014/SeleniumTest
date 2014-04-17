using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net.Util;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium;

namespace TestProject.About51
{
    /// <summary>
    /// 帮助类，一般引用第三方
    /// NPOI：http://npoi.codeplex.com/。
    /// 引用NPOI.dll
    /// </summary>
    /// 
     
    internal class Helper
    {


        public static void NPOIHelper(string filePath, string sheet, string testName, string testTime,
            String excepedResult, string actualResult)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfWork = new HSSFWorkbook(file);
            ISheet iSheet = hssfWork.GetSheet(sheet);
            int i = iSheet.LastRowNum + 1;
            iSheet.CreateRow(i).CreateCell(0).SetCellValue(testName);
            iSheet.GetRow(i).CreateCell(1).SetCellValue(testTime);
            iSheet.GetRow(i).CreateCell(2).SetCellValue(excepedResult);
            iSheet.GetRow(i).CreateCell(3).SetCellValue(actualResult);
            FileStream fss = new FileStream(filePath, FileMode.Create);
            hssfWork.Write(fss);
            file.Close();
        }

        public static void log4netHelper(string filePath)
        {


            //Application.Run(new MainForm());
            //创建日志记录组件实例
            log4net.ILog iLog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            iLog.Error("Error", new Exception("发生异常"));
            //记录严重错误
            iLog.Fatal("Error", new Exception("发生一个致命的错误"));
            //记录一般信息
            iLog.Info("Info");
            //记录调试信息
            iLog.Debug("debug");
            //记录警告信息
            iLog.Warn("warn");
            Console.WriteLine("日志记录完毕。");
            Console.Read();
        }

        public static IWebDriver OpenFireFoxDriver(string URL)
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            return driver;
        }

        public static IWebDriver OpenIEDriver(string URL)
        {
            var driver =
                new InternetExplorerDriver(
                    @"C:\Users\liu\Documents\visual studio 2012\Projects\TestProject\TestProject\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            return driver;
        }

        public static void AutoitHelper(string filePath)
        {

            //selenium 无法直接操作windows窗口，调用autoit来模拟用户操作
            var Autoit = new AutoItX3();
            const string widowTitle = "[Class:#32770]"; //上传窗口的类名：Class:#327700
            Autoit.WinWait(widowTitle, "File Upload", 1); //暂停执行脚本，直到上传对话框出现
            Autoit.WinActivate(widowTitle, "File Upload"); //激活上传窗口
            Autoit.ControlFocus(widowTitle, "File Upload", "[CLASS:Edit; INSTANCE:1]"); //控制焦点在输入框上
            //Autoit.ControlSetText(widowTitle, "", "[CLASS:Edit; INSTANCE:1]", "D:\\temp\\Desert.jpg"); //这行代码是另一个输入路径的方法            
            Autoit.Send(filePath); //输入文件路径  Microsoft Toolkit.exe
            Autoit.Sleep(1000);
            Autoit.Send("{ENTER}");
            Thread.Sleep(500);
        }

        public static IWebDriver DMLogin(string Url, string UserName, string Password)
        {
            //var driver = new InternetExplorerDriver(@"C:\Users\liu\Documents\visual studio 2012\Projects\TestProject\TestProject\");
            //var driver=new FirefoxDriver();
            var driver = new ChromeDriver(@"C:\Users\liu\Documents\visual studio 2012\Projects\TestProject\TestProject\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
            driver.FindElement(By.Id("UserName")).SendKeys(UserName);
            driver.FindElement(By.Id("Password")).SendKeys(Password);
            driver.FindElement(By.Id("login_button_credentials")).Submit();
            Thread.Sleep(2000);
            return driver;
        }



        public static ISelenium OpenChromeDriverRemote(string IP, int i, string website, string URL)
        {

            ISelenium selenium = new DefaultSelenium(IP, i, website, URL);
            selenium.Start();
            selenium.Open("/");
            return selenium;

        }
    }
}
