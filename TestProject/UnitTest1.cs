using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Selenium;

namespace TestProject
{
    [TestFixture]
    public class Webdriver
    {

        private ISelenium selenium;
        private StringBuilder verificationErrors;


        [SetUp]
        public void SetupTest()
        {
            selenium =new DefaultSelenium("saucelabs.com",4444,"{\"username":"}");
        selenium.Start();
            verificationErrors=new StringBuilder();
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
    
}
