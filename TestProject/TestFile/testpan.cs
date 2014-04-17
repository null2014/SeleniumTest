using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
[TestFixture]
public class testpan
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
public void TheTestpanTest()
{
			selenium.Open("/Account/LogOn?ReturnUrl=%2fHome%2fIndex");
            selenium.WaitForPageToLoad("30000");
           
            selenium.GetXpathCount("//input[@id='UserName']['type=text']");
            selenium.GetXpathCount("//input[@id='Password']");
            selenium.Type("id=UserName", "cman@azaas.com");
            
           selenium.Type("id=Password", "111111");
           
           selenium.Click("id=RememberMe");
          
           selenium.GetXpathCount("//input[@id='login_button_credentials']['type=button']");
           selenium.Click("//input[@id='login_button_credentials']");
           selenium.WaitForPageToLoad("50000");
           selenium.CaptureScreenshot("d:\\123.png");
           selenium.Click("link=退出");
			
}
}
}
