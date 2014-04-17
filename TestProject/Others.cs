using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TestProject.Help;

namespace TestProject
{
    internal class Others
    {
        

        [Test]
        public void ChangePassword()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.iconcgo.com:8080/icongo.server/userRelated-UserRelated-czmm.action");
            driver.FindElement(By.Id("remail")).Click();
            driver.FindElement(By.CssSelector("div.rg_btn a")).Click();
            driver.FindElement(By.Id("email")).SendKeys("test0086@163.com");
            driver.FindElement(By.CssSelector("div.rg_btn a")).SendKeys("\n");
            //driver.FindElement(By.CssSelector("table.l-dialog-table div.l-dialog-btn-inner")).Click();
            //driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr[2]/td[2]/div/div[3]/div/div[1]/div[3]")).Click();
            driver.FindElement(By.CssSelector("document.querySelector('table.l-dialog-table div.l-dialog-btn-inner')"));

        }

        [Test]
        public void htmlWriter()
        {
            var driver = new FirefoxDriver();
            driver.Navigate()
                .GoToUrl(
                    "http://detail.tmall.com/item.htm?spm=a230r.1.14.1.inJoZY&id=21789347135&ad_id=&am_id=&cm_id=140105335569ed55e27b&pm_id=");

            driver.FindElement(By.CssSelector("li.tm-selected > a"));

        }

        [Test]
        public void IETest()
        {
            var driver =
                new InternetExplorerDriver(@"C:\Users\liu\Documents\Visual Studio 2012\Projects\TestProject\TestProject");
            driver.Navigate().GoToUrl("http://www.baidu.com");

        }

        [Test]
        public void ChromeTest()
        {
            var driver = new ChromeDriver(@"C:\Users\liu\Documents\Visual Studio 2012\Projects\TestProject\TestProject");
            driver.Navigate().GoToUrl("http://www.google.com");
        }


        [Test]
        public void baiduTest()
        {
            var mainWindow = new FirefoxDriver();
            INavigation navigation = mainWindow.Navigate();
            navigation.GoToUrl("http://www.baidu.com/");
            IWebElement btnMainWindow = mainWindow.FindElement(By.Name("tj_reg"));
            btnMainWindow.Click();
            System.Collections.Generic.IList<string> handles = mainWindow.WindowHandles;

            //for (int i=0;i<handles.Count;i++)
            //{
            //    Console.WriteLine(handles[i]);
            //}
            //Console.ReadKey();

            IWebDriver childWindow = mainWindow.SwitchTo().Window(handles[1]);
            IWebElement txchildWindow = childWindow.FindElement(By.Id("TANGRAM__PSP_4__account"));
            txchildWindow.SendKeys("1234567");

        }

        [Test]
        public void WindowHandleTest()
        {
            var mainWindow = new FirefoxDriver();
            INavigation navigation = mainWindow.Navigate();
            navigation.GoToUrl("http://www.hao123.com");
            IWebElement btnMainWindow = mainWindow.FindElement(By.XPath("//*[@id='site']/div/ul/li[1]/a"));
            btnMainWindow.Click();
            System.Collections.Generic.IList<string> handles = mainWindow.WindowHandles; //获取窗口的数量
            IWebDriver childWindow = mainWindow.SwitchTo().Window(handles[1]); //定位到第一个窗口
            IWebElement textchildWindow = childWindow.FindElement(By.Id("kw"));
            textchildWindow.SendKeys("selenium");
            IWebElement buttonElement = childWindow.FindElement(By.Id("su"));
            buttonElement.Click();
            mainWindow.SwitchTo().Window(handles[0]); //回到主窗口
        }

        [Test]
        public void CookiesTest()
        {
            IWebDriver mainWindow = new FirefoxDriver();
            INavigation navigation = mainWindow.Navigate();
            navigation.GoToUrl("http://www.google.com.hk/");
            ICookieJar cookies = mainWindow.Manage().Cookies;


            string stamp = DateTime.Now.ToString("s");
            stamp = stamp.Replace(":", "-");
            string path1 = "d:\\temp\\TestResluts-" + stamp + ".txt";
          
            FileStream fsStream = new FileStream(path1, FileMode.Create);
            StreamWriter swWriter = new StreamWriter(fsStream);
            swWriter.WriteLine("当前cookie 数量为：" + cookies.AllCookies.Count);
            for (int i = 1; i < cookies.AllCookies.Count; i++)
            {
                
                swWriter.WriteLine("第" + i + "个cookie的属性如下：");
                swWriter.WriteLine("cookie名称：" + cookies.AllCookies[0].Name);
                //Console.WriteLine("第" + i + "个cookie的属性如下：");
                //Console.WriteLine("cookie名称：" + cookies.AllCookies[0].Name);
                //Console.WriteLine("cookie 值：" + cookies.AllCookies[0].Value);
                //Console.WriteLine("cookie路径：" + cookies.AllCookies[0].Path);
                //Console.WriteLine("cookies的过期时间：" + cookies.AllCookies[0].Expiry);
            }
            swWriter.Close();
            fsStream.Close();
            ////添加cookies
            //Cookie newCookie = new Cookie("new cookie", "chinacloudapp.cn", "", DateTime.Now.AddDays(1));
            //cookies.AddCookie(newCookie);
            //Console.WriteLine("新增的cookie的名称：" + newCookie.Name);

            //Console.WriteLine("新增的cookie的路径：" + newCookie.Path);
            //Console.WriteLine("新增的cookies的过期时间：" + newCookie.Expiry);

            ////输出新增后cookie的数量
            //Console.WriteLine("新增后的所有cookie数量：" + cookies.AllCookies.Count);


            ////删除新增的cookie
            //cookies.DeleteCookie(newCookie);
            //Console.WriteLine("删除新增的cookie的数量为：" + cookies.AllCookies.Count);
        }

        [Test]

        public void MoXinTest()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://yxhk.moxian.com/user/login?redirect_url=http://yxhk.moxian.com/");
            driver.FindElement(By.Id("txtEmailUser")).SendKeys("xuekui_it@163.com");
            driver.FindElement(By.Id("txtEmailPwd")).SendKeys("xuekui123");
            driver.FindElement(By.CssSelector("a.signbtn > span")).Click();
            Thread.Sleep(1000);
            //driver.ExecJavascript("document.querySelector('#userSearchBox').style.display= 'block'");
            //driver.FindElement(By.Id("top_search_input")).Clear();
            driver.FindElement(By.Id("top_search_input")).SendKeys("a");
            driver.FindElement(By.Id("top_search_input")).Click();

            //字符加空格方法
            //driver.FindElement(By.Id("top_search_input")).SendKeys("\0");//"\0"表示空格

            //执行js方法 
            var js_displayTheMenuBlock = 
                string.Format("document.querySelector('#userSearchBox').style.display= 'block'");
                //找到js
            ((IJavaScriptExecutor) driver).ExecuteScript(js_displayTheMenuBlock); //强制执行js
        }


        public static void ExecJavascript(IWebDriver webDriver, string jsCode)
        {
            ((IJavaScriptExecutor) webDriver).ExecuteScript(jsCode);
        }

        [Test]
        public void TestPanUpload()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://testpan.chinacloudapp.cn");

            while (driver.Url != "http://testpan.chinacloudapp.cn/Files/Index")
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
            driver.FindElement(By.CssSelector("li.li-header_files > a > img")).Click();

            // driver.FindElement(By.XPath("//ul[@id='tabMenu']/li[2]")).GetCssValue("Select");
            //WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            // waiter.Until(w => w.FindElement(By.CssSelector(("li.Select"))).Text == "Select");

            var js_TabMenu =
                string.Format("document.querySelector('#tabMenu > li[data-op='Personal_Space']').Class='Select'");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("a.menuBtn_upload > span.icontxt")).Click();

            var js_UploadFile = string.Format("document.querySelector('#fileToUpload').className='12'");
            ((IJavaScriptExecutor) driver).ExecuteScript(js_UploadFile);

            driver.FindElement(By.Id("fileToUpload")).SendKeys("D:\\log.txt");
            driver.FindElement(By.CssSelector("table.table-pw_next a.btn_upload")).Click();

        }

        [Test]
        public void CreateHtml()
        {
            FileStream testHtml = new FileStream(@"d:\temp\test.html", FileMode.Create, FileAccess.Write);
            //testHtml.Close();
            StreamWriter htmlWriter = new StreamWriter(testHtml, Encoding.UTF8);

            htmlWriter.WriteLine("<title>Report</title>");
            //htmlWriter.WriteLine("<table border='1'><tr><td>TestTime</td><td>TestCase</td><td>TestResult</td></tr></table>");
            htmlWriter.WriteLine("report Time:", System.DateTime.Now);


            htmlWriter.Close();

            testHtml.Close();
            //File.OpenWrite(@"d:\temp\test.html").Write


        }

        [Test]
        public void TestTryCatch()
        {
            //try
            //{
            //    FileStream fs = File.Open(@"c:\1.TXT", FileMode.Open);
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message, e);
            //}
            int[] ff = new int[5] {1, 2, 3, 4, 6};
            try
            {
                for (int i = 0; i <= ff.Length; i++)
                {
                    Console.WriteLine(ff[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        public void makeTest()
        {
            var mainWindow = new FirefoxDriver();
            mainWindow.Manage().Window.Maximize();
            mainWindow.Navigate()
                .GoToUrl(
                    "http://my.b2b.makepolo.com/ucenter/login/login.php?gotourl=http%3A%2F%2Fmy.b2b.makepolo.com%2Fucenter%2F");
            mainWindow.FindElement(By.Id("new_username")).SendKeys("342581947@qq.com");
            mainWindow.FindElement(By.Id("new_passwd")).SendKeys("123456");
            mainWindow.FindElement(By.CssSelector("#new_submitBtn > a")).Click();
            Thread.Sleep(5000);

            var js_displayBlock =
                string.Format("document.querySelector('div.d-titleBar > a.d-close').style.display=' block'");

            ((IJavaScriptExecutor) mainWindow).ExecuteScript(js_displayBlock);
            mainWindow.FindElement(By.CssSelector("div.d-titleBar > a.d-close")).Click();

            //mainWindow.FindElement(By.XPath("div[@class='menu']/dl[4]/dd[1]/a")).Click();
            mainWindow.FindElement(By.LinkText("发布产品")).Click();
            mainWindow.FindElement(By.CssSelector("div.product_post_one > a.product_post_btn")).Click();
            //mainWindow.FindElement(By.CssSelector("div.i_freepost > a.i_freepost_supply")).Click();
            System.Collections.Generic.IList<string> handles = mainWindow.WindowHandles;
            IWebDriver oneWindow = mainWindow.SwitchTo().Window(handles[1]);

            IWebElement textchildWindow =
                oneWindow.FindElement(By.CssSelector("div.postProduct_textBox > input.postProduct_textBox_text"));
            textchildWindow.SendKeys("手机");
            IWebElement btnWindow =
                oneWindow.FindElement(By.CssSelector("div.postProduct_textBox > input.postProduct_textBox_btn"));
            btnWindow.Click();
            Thread.Sleep(5000);

            IWebElement radioElement = oneWindow.FindElement(By.XPath("//*[@id='tj_cat']/li[1]/label/span"));
            radioElement.Text.Equals("家电、手机、数码 > 手机、通讯及配件 > 手机保护套/保护壳");
            IWebElement btn2Element = oneWindow.FindElement(By.CssSelector("input.postProduct_nextstep"));
            btn2Element.Click();


            //tyr{        
// // Loop throgh all products till get "iPhone 4S" name
// for (int i = 1; i < 9; i++) {
// if(myTestDriver.findElement(By.xpath("//*[@id='product_list']/li["+i+"]/div[2]/h3/a")).getText().equals("iPhone 4S")){

// // click on "iPhone 4S" named product
// myTestDriver.findElement(By.xpath("//*[@id='product_list']/li["+i+"]/div[3]/a")).click();

// }
// }

//} catch (Exception e) {

// }


// }
// }



            //radioElement.FindElement(By.TagName("18,550"));
            ////var radioElement =
            //  oneWindow.FindElement(
            //  By.CssSelector("ul[value='18,550']"));
            //var mouseOverAction = new OpenQA.Selenium.Interactions.Actions(oneWindow);
            //mouseOverAction.MoveToElement(radioElement);

            //mouseOverAction.Perform();
            radioElement.Click();

            IWebElement nextElement =
                oneWindow.FindElement(By.CssSelector("p.postProduct_btn > input.postProduct_nextstep"));
            nextElement.Click();
        }




        [Test]
        public void make2Test()
        {
            var mainWindow = new FirefoxDriver();
            mainWindow.Navigate().GoToUrl("http://china.makepolo.com/");



        }

        [Test]
        public void StartBrowser()
        {
            var driver = new FirefoxDriver();
        }


        [Test]
        public void CloseBrowser()
        {
            var driver = new FirefoxDriver();
            driver.Quit();

        }

        [Test]
        public void MaxBrowser()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Quit();
        }

        [Test]
        public void GoToUrl()
        {
            var driver = new FirefoxDriver(); //当然可以使用其他浏览器
            driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.Quit();
        }

        [Test]
        public void SettingBrowser()
        {
            var driver = new FirefoxDriver();

            driver.Manage().Window.Position.Offset(500, 0);
            Thread.Sleep(2000);
            driver.Quit();
        }

        IWebDriver driver=new FirefoxDriver();
        public static string baiDuTitle = "百度一下，你就知道";
        public static string baiDuURL = "http://www.baidu.com";
        public bool IsTitle
        {
            get { return driver.Title.Equals(baiDuTitle); }
        }

        public bool IsURL
        {
            get { return driver.Url.Contains(baiDuURL); }
        }

        [Test] 
        //提取打开浏览器到公用，
        public void switchTOPage()
        {           
            driver.Navigate().GoToUrl("http://www.baidu.com");
            if (IsTitle==true)
            {
                Console.WriteLine("成功打开百度");
            }
            else
            {
                Console.WriteLine("没有打开百度！");
            }
            if (IsURL==true)
            {
                Console.WriteLine("打开的网址为：{0}",baiDuURL);
            }
            else
            {
                Console.WriteLine("打开的网址不是：{0}",baiDuURL);
            }
        }

        [Test]
        public void GoBackAndForward()
        {
           
            driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.FindElement(By.Id("kw")).SendKeys("selenium");
            driver.FindElement(By.Id("su")).Click();
            driver.Navigate().Back();
            driver.Navigate().Forward();
        }

        [Test]
        public void Locate()
        {
            
           driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.FindElement(By.LinkText("搜索设置")).Click();
        }

   


        [Test]
        public void OpenBaiduTest()
        {
            IWebDriver driver = new FirefoxDriver();
            //打开浏览器并跳转到百度搜索
            driver.Navigate().GoToUrl("http://www.baidu.com");

            //验证打开百度页面后浏览器标题包含“百度一下”
            Assert.True(driver.Title.Contains("百度一下"));
        }

        [Test]
        //处理对话框，按确定按钮；Dismiss()为取消按钮
        public void Accept()
        {
            
            driver.Navigate().GoToUrl("C:\\Users\\liu\\Documents\\" +
                           "visual studio 2012\\Projects\\TestProject\\TestProject\\Test.html");
            driver.FindElement(By.ClassName("btnAlert")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("confirm")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Name("prompt")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void Cookie()
        {
            driver.Navigate().GoToUrl("http://www.baidu.com");
            ICookieJar cookies = driver.Manage().Cookies;

            for (int i = 1; i <=cookies.AllCookies.Count; i++)
            {
                Console.WriteLine("第"+i+"cookie的属性为");
                Console.WriteLine("name为："+cookies.AllCookies[1].Name);
                Console.WriteLine("Value为："+cookies.AllCookies[1].Value);
                Console.WriteLine("Path为:"+cookies.AllCookies[1].Path);
            }
            //增加cookie
            OpenQA.Selenium.Cookie newcookie=new Cookie("newcookie","baidu","新cookie");
            cookies.AddCookie(newcookie);
            Console.WriteLine("新cookie的path:"+newcookie.Path);
            Console.WriteLine("新cookie 的name:"+newcookie.Name);
            Console.WriteLine("新cookie的value:"+newcookie.Value);
            

        }

        [Test]
        public void GetAttrib()
        {
            driver.Navigate().GoToUrl("http://www.google.com.hk");
            IWebElement btn=driver.FindElement(By.Name("btnK"));            
            string btnValue = btn.GetAttribute("value");
            Console.WriteLine("google的属性为："+btnValue);
            
        }

        [Test]
        public void DisplayedorNo()
        {
            driver.Navigate().GoToUrl("http://www.google.com.hk");
            IWebElement btn = driver.FindElement(By.Name("btnK"));
            bool visiblility = btn.Displayed;//all the same:enable/selected/tagname
            Console.WriteLine("元素是否显示为："+visiblility);
           
        }

        [Test]
        public void SwitchTO()
        {
            INavigation inavigation = driver.Navigate();
            inavigation.GoToUrl("http://www.hao123.com");
            IWebElement drivElement = driver.FindElement(By.XPath("//*[@id='site']/div/ul/li[1]/a"));
            drivElement.Click();
            System.Collections.Generic.IList<string> handle = driver.WindowHandles;
            IWebDriver oneWindow = driver.SwitchTo().Window(handle[1]);
            IWebElement onElement = oneWindow.FindElement(By.Id("kw"));
            onElement.SendKeys("seleium");
            IWebElement btnElement = oneWindow.FindElement(By.Id("su"));
            btnElement.Click();

        }

        [Test]
        public void Sendkey()
        {
            driver.Navigate().GoToUrl("http://www.baidu.com");
            driver.FindElement(By.Id("kw")).SendKeys("selenium");
            driver.FindElement(By.Id("su")).SendKeys("\n");
        }

        [Test]
        public void QTest()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://17186.cn/business/business_detail.3.jsp?columnId=92470&resourceCode=208654&version=3&unikey=ea1dd33180794db683bd17868ce4de7a");
            var js_displayBlock = string.Format("document.querySelector('#slide_nav').style.display=' block'");
            ((IJavaScriptExecutor)driver).ExecuteScript(js_displayBlock);
            driver.FindElement(By.XPath("//*[@id='slide_nav']/ul/li[2]/div/a/span")).Click();
            System.Collections.Generic.IList<string> handles = driver.WindowHandles;
            IWebDriver OneHandle = driver.SwitchTo().Window(handles[1]);


        }


        [Test]
        public void JDTest()
        {
            
        }
    }
}

        
   

