using NUnit.Framework;
using Selenium;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumTests
{
[TestFixture]
public class fabu
{
private ISelenium selenium;
private StringBuilder verificationErrors;

[SetUp]
public void SetupTest()
{
selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "http://testpan.chinacloudapp.cn/");
selenium.Start();
verificationErrors = new StringBuilder();
}

[TearDown]
public void TeardownTest()
{
try
{
selenium.Stop();
}
catch (Exception)
{
// Ignore errors if unable to close the browser
}
Assert.AreEqual("", verificationErrors.ToString());
}

[Test]
public void TheFabuTest()
{
            selenium.Open("/Account/LogOn?ReturnUrl=%2fHome%2fIndex");
            selenium.WaitForPageToLoad("30000");
            selenium.GetXpathCount("//input[@id='UserName']");
			selenium.Type("id=UserName", "cman@azaas.com");
            selenium.GetXpathCount("id=Password");
			selenium.Type("id=Password", "111111");
			selenium.Click("id=login_button_credentials");
			selenium.WaitForPageToLoad("50000");
			selenium.Click("link=发布公告");
			selenium.Type("id=publicItemTitle", "898989");

            //string dom=Document.getElementById("SinaEditor_Iframe").firstChild.contentWindow.document.body;
            //String iframeXPath = "//div/iframe[@id]";
            //selenium.selectFrame("xpath=//div/iframe[@publicItemContent]");
            selenium.Type("id=publicItemContent","rwioeuroiweuri");
			selenium.Click("link=发布");
            selenium.WaitForPageToLoad("40000");
            selenium.CaptureScreenshot("d:\\12.png");
			selenium.Click("link=退出");
			selenium.WaitForPageToLoad("30000");
}
}
}
