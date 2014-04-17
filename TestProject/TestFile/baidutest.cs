using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class baidutest
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("192.168.1.130", 4444, "*iexplore", "http://www.baidu.com/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        //[TearDown]
        //public void TeardownTest()
        //{
        //    try
        //    {
        //        //selenium.Stop();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //    }
        //    Assert.AreEqual("", verificationErrors.ToString());
        //}

        [Test]
        public void TheBaidutestTest()
        {
            selenium.Open("/");
            selenium.Type("id=kw", "hyddd");
            selenium.Click("id=su");
            selenium.WaitForPageToLoad("30000");
            try
            {
                Assert.IsTrue(selenium.IsTextPresent("hyddd - 博客园"));
                //div[@id='1']//h3   
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            //string linkText = selenium.GetText("target=_blank");
            selenium.Click("link=hyddd - 博客园");
            //selenium.Click(linkText);
            //Assert.IsTrue(selenium.GetAllLinks("hyddd - 博客园"))
        }
    }
}