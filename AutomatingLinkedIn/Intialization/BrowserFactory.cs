using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Intialization
{
    class BrowserFactory
    {
        IWebDriver driver;
        public IWebDriver StartBrowser(String browserName)
        {
            try
            {
                if (browserName.ToLower().Equals(""))
                {
                    throw (new Exception("BROWSER_NAME is not specified"));
                }
                if (browserName.ToLower().Equals("chrome"))
                {
                    driver = new ChromeDriver();
                }
                if (browserName.ToLower().Equals("firefox"))
                {
                    driver=new FireFoxDriver();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return driver;
        }
    }
}
