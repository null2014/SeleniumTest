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
            selenium = new DefaultSelenium("127.0.0.1", 4444, "*chrome", "http://www.baidu.com/");
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
        public void TheBaidutestTest()
        {
            selenium.Open("/");
            selenium.Type("id=kw", "hyddd");
            selenium.Click("id=su");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=hyddd - 博客园");
        }
    }
}