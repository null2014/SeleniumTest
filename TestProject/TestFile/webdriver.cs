
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;

namespace SeleniumTests
{
    [TestFixture]
    public class Webdriver
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private IWebElement webTable;


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
        //login
        public void TheWebdriverTest()
        {
            driver.Navigate().GoToUrl(baseURL);

            ITimeouts timeouts = driver.Manage().Timeouts();
            ////忘记密码
            //driver.FindElement(By.LinkText("忘记密码?")).Click();
            ////忘记密码检查点
            //Console.WriteLine("检查登录成功页面是否跳转到http://testpan.chinacloudapp.cn/Account/Forgot:{0}", "http://testpan.chinacloudapp.cn/Account/Forgot" == driver.Url);
            //Thread.Sleep(1000);
            //Assert.AreEqual(driver.Url, "http://testpan.chinacloudapp.cn/Account/Forgot");
            //driver.Navigate().Back();
            //Thread.Sleep(1000);

            ////免费试用
            //driver.FindElement(By.LinkText("免费试用")).Click();
            //Console.WriteLine("成功跳转到免费使用界面http://testpan.chinacloudapp.cn/Account/register：{0}", "http://testpan.chinacloudapp.cn/Account/register" == driver.Url);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            //Thread.Sleep(1000);


            //driver.FindElement(By.Id("UserName")).Click();
            //driver.FindElement(By.Id("UserName")).Clear();
            //driver.FindElement(By.Id("UserName")).SendKeys("cman@azaas.com");
            //driver.FindElement(By.Id("Password")).Clear();
            //driver.FindElement(By.Id("Password")).SendKeys("111111");
            //driver.FindElement(By.Id("login_button_credentials")).Click();
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("cman@azaas.com");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();

                //设置登录检查点
                Console.WriteLine("检查登录成功页面是否跳转到http://testpan.chinacloudapp.cn/Home/Index:{0}",
                    "http://testpan.chinacloudapp.cn/Home/Index" == driver.Url);
                Thread.Sleep(1000);

                //Assert.AreEqual(driver.FindElement(By.Id("errorArea")).Text, "请输入验证码");
                //Assert.AreEqual(driver.FindElement(By.Id("errorArea")).Text, "请输入用户名");
                //Assert.AreEqual(driver.FindElement(By.Id("errorArea")).Text, "登录失败，您输入的账号或密码有误！");
            }
            //Assert.AreEqual(driver.Url, "http://testpan.chinacloudapp.cn/Home/Index");
        }


        [Test] //发布公告
        public void Announcement()
        {

            driver.Navigate().GoToUrl(baseURL);

            ITimeouts timeouts = driver.Manage().Timeouts();
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("cman@azaas.com");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }

            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector("a.menuBtn_announcementcreate")).Click(); //此系统为多语言，所以不要出现页面文字元素
            driver.FindElement(By.Id("publicItemTitle")).Clear();
            driver.FindElement(By.Id("publicItemTitle")).SendKeys("89899uiuo089");
            driver.FindElement(By.Id("publicItemPublisher")).Clear();
            driver.FindElement(By.Id("publicItemPublisher")).SendKeys("cman");
            //跳转入frame，并输入信息
            driver.FindElement(
                By.XPath("//*[@id='window_announcementcreate']/div/div[2]/table/tbody/tr[6]/td/div/div[2]/iframe"))
                .SendKeys("7978uoiuoiU9809iuiouoiuoi");
            driver.FindElement(By.CssSelector("a.btn_ok")).Click();
            //  Thread.Sleep(30);
            //  Console.WriteLine("公告标题是：{0}", driver.FindElement(By.Id("titleDiv")).Text);
            // // IWebElement el= driver.FindElement(By.XPath("/div/div[2]/div/div[2]/iframe"));
            //// driver.SwitchTo().Frame(el);


            // //driver.FindElement(By.CssSelector("div#window_announcementcreate div.ToolBar+div > iframe > html > head > body >")).SendKeys("ffffff"); 

            // //driver.FindElement(By.Id("publicItemContent")).SendKeys("98ui78u989");

            // ////跳转入frame,并输入信息
            // //driver.SwitchTo().Frame(FrameElement).FindElement(By.XPath("html/body")).sendKeys("xxxxxx");
            // ////跳出frame
            // //driver.SwitchTo().defaultContent();

        }

        [Test] //创建文件夹
        public void CreateFolder()

        {
            driver.Navigate().GoToUrl(baseURL);

            ITimeouts timeouts = driver.Manage().Timeouts();
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("cman@azaas.com");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 30));
            driver.FindElement(By.CssSelector("li.li-header_files > a > img")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 50));
            driver.FindElement(By.CssSelector("a.menuBtn_create > span.icontxt")).Click();
            driver.FindElement(By.CssSelector("input.txt-fileName")).Clear();
            driver.FindElement(By.CssSelector("input.txt-fileName")).SendKeys("dduiuiuddd");
            // Console.WriteLine("新建的文件夹名字为：{0}", driver.FindElement(By.Id("commandList")).Text.Contains("dduiuiuddd"));
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("div.fileCommand > span.MixiTai_Checkbox")).Click();
            driver.FindElement(By.CssSelector("a.delete > input[type=\"button\"]")).Click();
            driver.FindElement(
                By.CssSelector(
                    "#window_delete > div.BorderWidth > div.boxfooter > table.table-fpw_operation > tbody > tr > td > a.btn_ok"))
                .Click();
            driver.FindElement(By.CssSelector("table.table-btn > tbody > tr > td > a.btn_ok")).Click();
        }

        [Test] //空间重命名
        public void RemanFolder()
        {

            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 30));
            driver.FindElement(By.CssSelector("li.li-header_files > a > img")).Click();
            driver.FindElement(By.CssSelector("div.fileCommand > span.MixiTai_Checkbox")).Click();
            driver.FindElement(By.CssSelector("a.rename > input[type=\"button\"]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[14]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[14]")).SendKeys("fffff");


        }


        //上传


        [Test]
        public void upLoad()
        {
            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("a.menuBtn_upload")).Click();
            //driver.FindElement(By.CssSelector("#a-pw_add > span.icontxt")).Click();
            //Thread.Sleep(1000);
            //Thread x = new Thread(new ThreadStart(Upload_File));
            //x.Start();
            //Thread.Sleep(1000);
            //driver.FindElement(By.CssSelector("table.table-pw_next a.btn_upload")).Click();
            //Thread.Sleep(2000);

            ////如果进度元素不是显示100，那么继续上传
            //if (driver.FindElement(By.XPath("//[@id='efaf3e61-c983-4dc3-9622-436d51d5a88c']/sapn[3]")).Text.Contains()!=100)
            //{

            //}

            //下载
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//ul[@id='commandList']/li/table/tbody/tr/td/div/span")).Click();
            ////driver.FindElement(By.CssSelector("div.fileCommand span.MixiTai_Checkbox")).Click();
            ////driver.FindElement(By.XPath("//ul[@id='commandList']/li[1]/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td/span")).Click();
            //driver.FindElement(By.XPath("(//input[@value='Open'])")).Click();
            ////driver.FindElement(By.CssSelector("a.option_Open")).Click();
            //Thread.Sleep(100);
            ////driver.FindElement(By.CssSelector("div.fileCommand span.MixiTai_Checkbox")).Click();           
            //driver.FindElement(By.XPath("//ul[@id='commandList']/li/table/tbody/tr/td/div/span")).Click();
            //Thread.Sleep(100);
            //driver.FindElement(By.XPath("(//input[@value='Open'])")).Click();
            ////driver.FindElement(By.CssSelector("a.menuBtn_return > span.icontxt")).Click();
            //driver.FindElement(By.XPath("//ul[@id='commandList']/li[2]/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td/span")).Click();
            //driver.FindElement(By.XPath("(//input[@value='Open'])[2]")).Click();
            //driver.FindElement(By.CssSelector("a.menuBtn_downLoad > span.icontxt")).Click();
            //driver.FindElement(By.CssSelector("a.menuBtn_downLoad > span.icontxt")).Click();
            //driver.FindElement(By.XPath("//div[@id='FilesView']/div[3]/a/span")).Click();


            var openFolderTableElement =
                driver.FindElement(
                    By.CssSelector("table[data-name='Angkor']"));

            var mouseOverAction = new OpenQA.Selenium.Interactions.Actions(driver);
            mouseOverAction.MoveToElement(openFolderTableElement);
            //notice： Actions必须要执行perform
            mouseOverAction.Perform();
            openFolderTableElement.FindElement(By.CssSelector("div.menuBtn a.option_Open")).Click();

            Thread.Sleep(1000);
            var openFileTableElement =
                driver.FindElement(
                    By.CssSelector("table[data-name='AppCertKitArmSetup.exe']"));

            var mouseOverAction1 = new OpenQA.Selenium.Interactions.Actions(driver);
            mouseOverAction1.MoveToElement(openFileTableElement);
            //notice： Actions必须要执行perform
            mouseOverAction1.Perform();
            openFileTableElement.FindElement(By.CssSelector("div.menuBtn a.option_Open")).Click();
            //driver.FindElement(By.LinkText("Download File")).Click();
            driver.FindElement(By.CssSelector("a.menuBtn_downLoad")).Click();
            Thread.Sleep(1000);
            var auto = new AutoItX3();
            //auto.Send("{BROWSE}");
            //Thread.Sleep(1000);

            //auto.Send("{TAB}");
            //auto.Send("{TAB}");
            //auto.Send("{ENTER}");
            Thread.Sleep(1000);
            const string widowTitle = "[Class:#32770]";
            auto.ControlFocus(widowTitle, "Choose Download Folder:", "[CLASS:Edit; INSTANCE:1]");
            auto.Send(@"C:");
            auto.ControlClick(widowTitle, "Choose Download Folder", "[CLASS:Button; INSTANCE:1]");
            auto.Send("{ENTER}");
            Thread.Sleep(5000);

            //driver.FindElement(By.LinkText("退出")).Click();
        }

        public void Upload_File()
        {
            var Autoit = new AutoItX3();
            const string widowTitle = "[Class:#32770]"; //上传窗口的类名：Class:#327700
            Autoit.WinWait(widowTitle, "文件上传", 1); //暂停执行脚本，直到上传对话框出现
            Autoit.WinActivate(widowTitle, "文件上传"); //激活上传窗口
            Autoit.ControlFocus(widowTitle, "文件上传", "[CLASS:Edit; INSTANCE:1]"); //控制焦点在输入框上
            //Autoit.ControlSetText(widowTitle, "", "[CLASS:Edit; INSTANCE:1]", "D:\\temp\\Desert.jpg"); //这行代码是另一个输入路径的方法            
            Autoit.Send(@"D:\azaas.jpg"); //输入文件路径
            Autoit.Sleep(1000);
            Autoit.Send("{ENTER}");
        

        //    //try
            //    //{
            //Autoit.ControlClick(widowTitle, "文件上传", "[CLASS:Button; INSTANCE:1]"); //点击Open
            //Autoit.Sleep(1000);
            //    //}
            //    //catch (Exception )
            //    //{
            //    //    Console.WriteLine("open按钮没有点击");
            //    //}
        }

        [Test]
        public void Add_User()
        {
            string nameData1 = "Tester1";
            string nameData2 = "Tester2";
            string EmailData = "test@azaas.com";
           // int SizeData = 2056;
            driver.Navigate().GoToUrl(baseURL);
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("angkor");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }
            Thread.Sleep(1000);
            //driver.FindElement(GroupLink).Click();
            driver.FindElement(By.XPath("//div[@id='header_content']/ul/li[4]/a/img")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("a.menuBtn_admincreate > span.icontxt")).Click();
            driver.FindElement(By.Id("adminLoginName")).SendKeys(nameData1);
            driver.FindElement(By.Id("adminName")).SendKeys(nameData2);
            driver.FindElement(By.Id("adminEmail")).SendKeys(EmailData);
            driver.FindElement(By.Id("adminSpace")).SendKeys("77797");
            driver.FindElement(By.CssSelector("a.btn_ok")).Click();

            //if (driver.FindElement(By.Id("Errormsg")).Text !=null )
            //{
            //    Thread.Sleep(100);
            //    driver.FindElement(By.Id("adminLoginName")).SendKeys("hi");
            //    driver.FindElement(By.Id("adminName")).SendKeys("hello");
            //    driver.FindElement(By.Id("adminEmail")).Clear();
            //    driver.FindElement(By.Id("adminEmail")).SendKeys("8777@azaas.com");
            //    driver.FindElement(By.Id("adminSpace")).Clear();
            //    driver.FindElement(By.Id("adminSpace")).SendKeys("2056");
            //    driver.FindElement(By.CssSelector("a.btn_ok")).Click();
            //}
            var userList = driver.FindElements(By.CssSelector(""));
            foreach (var user in userList)
            {
                if (user.Text == "shitname")
                {
                    return;
                }

                Assert.Fail("Can't find the user of xxx");

            }
        }

        [Test]
        public void Add_Group()
        {

            driver.Navigate().GoToUrl(baseURL);

            ITimeouts timeouts = driver.Manage().Timeouts();
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("angkor");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }


            driver.FindElement(GroupLink).Click();
            string groupName = "Dev";

            driver.FindElement(By.XPath("//ul[@id='tabMenu']/li[2]")).Click();
            driver.FindElement(By.CssSelector("a.menuBtn_groupcreate > span.icontxt")).Click();
            driver.FindElement(By.Id("groupName")).SendKeys(groupName);
            driver.FindElement(By.Id("groupDescription")).SendKeys("This is a test");
            //driver.FindElement(By.CssSelector("div.boxfooter > table.table-warp > a.btn_ok")).Click();

            driver.FindElement(By.XPath("//*[@id='window_EditGroup']/div/div[3]/table/tbody/tr/td[1]/a")).Click();
            //var groudNameLists = driver.FindElements(By.CssSelector("groupName"));


            //var driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
            //      ExpectedConditions.ElementIsVisible(By.Id("commandBar"))); //
            //Thread.Sleep(1000);

            // var groupNameLists = driver.FindElements(By.CssSelector("td.groupName > div.adminItem_tale_td_div"));

            // Assert.AreNotEqual(groupNameLists ,0, "没有获取到任何groupNameLists");

            // foreach (var groupNameList in groupNameLists)
            // {
            //     if (groupNameList.Text == groupName)
            //     {

            //         return;
            //     }
            // }

            // Assert.AreNotEqual("Can't not found group name is {0}",groupName);
            //driver.FindElement(By.XPath(groupName)).Click();
            var driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                ExpectedConditions.ElementIsVisible(By.Id("commandBar")));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[contains(text(),'Dev')]")).Click();
            driver.FindElement(By.CssSelector("a.menuBtn_groupdelete > span.icontxt")).Click();
            driver.FindElement(By.XPath("//*[@id='window_DeleteGroup']/div/div[3]/table/tbody/tr/td[1]/a")).Click();

            // var gN=driver.FindElement(By.CssSelector("td.groupName > div.adminItem_tale_td_div")).GetCssValue(groupName);

            driver.Quit();

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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public void LoginHelp()
        {

            driver.Navigate().GoToUrl(baseURL);

            ITimeouts timeouts = driver.Manage().Timeouts();
            while (driver.Url != "http://testpan.chinacloudapp.cn/Home/Index")
            {
                var userName = driver.FindElement(By.CssSelector("input#UserName"));
                userName.Clear();
                userName.SendKeys("cman@azaas.com");
                driver.FindElement(By.CssSelector("input#Password")).SendKeys("111111");
                driver.FindElement(By.CssSelector("input#ValidateCode"))
                    .SendKeys(CodeServiceClient.CodeService.GetCode());
                driver.FindElement(By.CssSelector("input#login_button_credentials")).Submit();
            }
        }

        public static
            By
            GroupLink
            {
                get
                {
                    return By.XPath("//div[@id='header_content']/ul/li[4]/a/img");

                }

            }
        }

    
} 
 


