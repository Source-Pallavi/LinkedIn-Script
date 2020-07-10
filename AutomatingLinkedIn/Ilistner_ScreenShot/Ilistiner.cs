using OpenQA.Selenium;
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
        static int i = 0;
        IWebDriver driver;
        public Ilistiner(IWebDriver driver)
        {
            this.driver = driver;
            SeleniumExtras.PageObjects.PageFactory.InitElements(driver, this);
            i++;
        }
        public Ilistiner()
        {
        }//zero param constructor

        public void ScreenShot()
        {
            Thread.Sleep(200);
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\ScreenShot/" + TakesScreenshotWithDate()+".png");

            //Will be update per screenshot that we took

            /*   public void ScreenShot2()
               {
                  ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\\Users\\rebel\\source", ScreenshotImageFormat.Jpeg);
                   TakesScreenshotWithDate(driver, @"C:\\Users\\rebel\\source\\repos\\Linkedin\\ScreenShot/", "SS", System.Drawing.Imaging.ImageFormat.Jpeg);
               }*/
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
