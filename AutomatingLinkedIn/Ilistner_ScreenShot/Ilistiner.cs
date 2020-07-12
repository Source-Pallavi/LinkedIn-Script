using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Ilistner_ScreenShot
{
   public class Ilistiner
    {
        IWebDriver driver;
        public Ilistiner(IWebDriver driver)
        {
            this.driver = driver;
           // PageFactory.InitElements(driver, this);

        }
        public Ilistiner()
        {
        }//zero param constructor

        public void ScreenShot()
        {
            Thread.Sleep(200);
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\ScreenShot\" + TakesScreenshotWithDate()+".png");

            //Will be update per screenshot that we took
        }
        private StringBuilder TakesScreenshotWithDate()
        {
            //Updates the number of screenshots that we took during the execution

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            return TimeAndDate;
        }

    }
}
