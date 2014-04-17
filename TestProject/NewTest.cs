using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace TestProject
{

    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {

        public ScreenShotRemoteWebDriver(Uri RemoteAdress, ICapabilities capabilities)
            : base(RemoteAdress, capabilities)
        {
        }

        /// <summary>
        /// Gets a <see cref="Screenshot"/> object representing the image of the page on the screen.
        /// </summary>
        /// <returns>A <see cref="Screenshot"/> object containing the image.</returns>
        public Screenshot GetScreenshot()
        {
            // Get the screenshot as base64.
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();

            // ... and convert it.
            return new Screenshot(base64);
        }


        [Test]
        public void newTest()
        {


            DesiredCapabilities ffCapabilities = DesiredCapabilities.Firefox();


            // And then the usage would be:
            ScreenShotRemoteWebDriver webDriver = new ScreenShotRemoteWebDriver(new Uri("http://www.baidu.com"),
                ffCapabilities);
            Screenshot ss = ((ITakesScreenshot) webDriver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("d:\\12.jpeg", ImageFormat.Jpeg);

        }

        [Test]
        public void Test2()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://tourism.51book.com/adminLogin.htm");
            driver.FindElement(By.Id("userName")).SendKeys("ZLBGYCS");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("submit")).Submit();
            driver.FindElement(By.XPath("/html/body/table/tbody/tr/td[1]/div/a[1]")).Click();
            driver.FindElement(By.Id("nextSteps")).Click();

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("");

        }


    }

}
