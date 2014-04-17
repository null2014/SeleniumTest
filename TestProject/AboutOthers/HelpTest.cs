using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.Util;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NUnit.Framework;
using NPOI.HSSF.UserModel;
using NPOI;
using NPOI.Util;
using NPOI.POIFS;
using System.IO;
using NPOI.HPSF;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Selenium;
using SeleniumTests;
using TestProject.About51;

namespace TestProject
{
    internal class Test
    {

        [Test]
        public void NPOITest()
        {
            HSSFWorkbook hssWorkbook = new HSSFWorkbook();
            ISheet hssSheet = hssWorkbook.CreateSheet("new sheet");
            //加入3个表格
            //hssWorkbook.CreateSheet("sheet1");
            //hssWorkbook.CreateSheet("sheet2");
            //hssWorkbook.CreateSheet("sheet3");

            //excel行从1开始，NPOI内部从0开始；excel列从字母开始，NPOI是数字表示，记得转换
            //加入单元格行和列
            hssSheet.CreateRow(0).CreateCell(0).SetCellValue("This a sample");
            hssSheet.GetRow(0).CreateCell(1).SetCellValue("This is a test");
            hssSheet.CreateRow(1).CreateCell(0).SetCellValue("This a sample");
            hssSheet.GetRow(1).CreateCell(1).SetCellValue("This is a test");
            ////这种方式比较麻烦
            //IRow hssRow = hssSheet.CreateRow(0);
            //hssRow.CreateCell(0).SetCellValue(1);

            FileStream fs = new FileStream(@"d:\temp\test.xls", FileMode.Create);
            hssWorkbook.Write(fs);
            fs.Close();

        }

        [Test]
        public void OpenExcelUseNPOI()
        {
            FileStream file = new FileStream(@"d:\temp\test.xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfWork = new HSSFWorkbook(file);
            ISheet iSheet = hssfWork.GetSheet("new sheet");
            iSheet.CreateRow(2).CreateCell(0).SetCellValue("Add test");
            iSheet.GetRow(2).CreateCell(1).SetCellValue("Add test1");
            FileStream fss = new FileStream(@"d:\temp\test.xls", FileMode.Create);
            hssfWork.Write(fss);
            file.Close();


        }

        [Test]
        public void AddExcelUserNPOI()
        {

            FileStream file = new FileStream(@"d:\temp\test.xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfWork = new HSSFWorkbook(file);
            ISheet iSheet = hssfWork.GetSheet("new sheet");
            iSheet.CreateRow(iSheet.LastRowNum + 1).CreateCell(0).SetCellValue("uuuu");
           
            FileStream fss = new FileStream(@"d:\temp\test.xls", FileMode.Create);
            hssfWork.Write(fss);
            file.Close();
        }

        [Test]
        public void TestExcel()
        {
            
            FileStream file = new FileStream(@"d:\temp\test.xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfWork = new HSSFWorkbook(file);
            ISheet iSheet = hssfWork.GetSheet("new sheet");
            //获取所有行数，然后再+1的基础上加入数据  （lastRowNum是当前数据的最后一行）         
            iSheet.CreateRow(iSheet.LastRowNum+1).CreateCell(0).SetCellValue("testtest");
            FileStream fss = new FileStream(@"d:\temp\test.xls", FileMode.Create);
            hssfWork.Write(fss);
            file.Close();
            
        }

        [Test]
        //在项目中引用log4net.dll
        public void Log4netTest()
        {
            string testTime = DateTime.Now.ToString("s");
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("Http://www.baidu.com");
            string expectedResult = "百度一下";
            string actualResult = driver.FindElement(By.Id("su")).GetAttribute("value");
            Console.WriteLine(actualResult);
            Assert.AreEqual(expectedResult,actualResult);
           // string fileName = "@d:\temp" + "\\" + System.DateTime.Now.ToString("yy-MM-dd") + "-log.log";
            // 和PatternLayout一起使用FileAppender
            Console.WriteLine(expectedResult);
         //log4net.Config.BasicConfigurator.Configure(new log4net.Appender.FileAppender(new log4net.Layout.PatternLayout("%d[%t]%-5p %c [%x] - %m%n"),"testfile.log"));

       // using a FileAppender with an XMLLayout
            log4net.Config.BasicConfigurator.Configure(new log4net.Appender.FileAppender(new log4net.Layout.XmlLayout(), "2014testfile.xml"));
        }

        [Test]
        public void TTestSelect()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://t.hexun.com/default.htm");
            var js_dispalyNull = string.Format("document.querySelector('#allnav').style.display=''");
            ((IJavaScriptExecutor) driver).ExecuteScript(js_dispalyNull);
           // driver.FindElement(By.XPath("//*[@id='secnav11']/ul/li[4]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='allnav']/dl/dd[1]/a")).Click();
            string exceptedResutl = "财经学者";
            string actualResult = driver.FindElement(By.CssSelector("div.gsdrtit li.btnOver")).Text;
            Assert.AreEqual(exceptedResutl,actualResult);
            


            //driver.FindElement(By.XPath("div[@node-type='menu']")).Click();
            //   var clickEelement=driver.FindElement(By.XPath("//*[@id='SI_Top_Wrap']/div/div/div/div[1]/div[2]/a/i"));
            //var mouseOnAction = new OpenQA.Selenium.Interactions.Actions(driver);
            //mouseOnAction.MoveToElement(clickEelement);
            //mouseOnAction.Perform();
            //clickEelement.Click();

        }


        [Test]
        public void NpoiTest()
        {
            string filePath = @"d:\temp\TestResult.xls";
            string sheet = "sheet1";
            string testName = "NpoiTest";
            string testTime = DateTime.Now.ToString("s");
            string exceptedResult = "12334";
            string actualResualt = "79898";
            
        Helper.NPOIHelper(filePath,sheet,testName,testTime,exceptedResult,actualResualt );
           

        }


        [Test]
        public void OpenFFWebDriver()
        {

          var driver= Helper.OpenFireFoxDriver("http://www.baidu.com");
            driver.FindElement(By.Id("kw")).SendKeys("selenium");
            driver.FindElement(By.Id("su")).Click();

        }

        [Test]
        //IE 无法启动
        public void OpenIEDriver()
        {
            var driver = Helper.OpenIEDriver("http://www.baidu.com");
            driver.FindElement(By.Id("kw")).SendKeys("selenium");
            driver.FindElement(By.Id("su")).Click();
        }

        [Test]
        public void Remote()
        {
            string ip = "192.168.1.84";
            int i = 4444;
            string website = "*firefox";
            string url = "http://www.baidu.com";
            ISelenium selenium= Helper.OpenChromeDriverRemote(ip,i,website,url);
           selenium.Type("id=kw", "slenium");
            selenium.Click("su");
            
        }

        [Test]
        public void WebDirverRemote()
        {
            //DesiredCapabilities ffCapabilities = DesiredCapabilities.Firefox();
            //DesiredCapabilities ffCapabilities=new DesiredCapabilities("*firefox","",Window7);
            //var driver = new RemoteWebDriver(new Uri("http://l92.168.1.84:4444/web/hub"),ffCapabilities);
            //driver.Navigate().GoToUrl("http://www.google.com");

            

        }
    }
}