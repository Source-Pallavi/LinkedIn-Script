using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Parallel_Session
{
    public class AutomationBase
    {
        public IWebDriver StartBrowser(String browserName)
        {
            IWebDriver driver= null;
            try
            {
                if (browserName.ToLower().Equals("")) throw (new Exception("BROWSER_NAME is not specified"));
                if (browserName.ToLower().Equals("chrome")) driver= new ChromeDriver();
                if (browserName.ToLower().Equals("firefox"))driver= new FirefoxDriver();
            }
            catch (Exception e)
            {
                 throw (e);
            }
            driver.Url = "https://www.linkedin.com/login";
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
