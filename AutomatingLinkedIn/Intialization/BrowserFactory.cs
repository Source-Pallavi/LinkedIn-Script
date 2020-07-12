using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Intialization
{
  public  class BrowserFactory
    {
       
       
        public static  IWebDriver StartBrowser(String browserName)
        {
            IWebDriver driver;
           
                if (browserName.ToLower().Equals(""))
                
                    throw (new Exception("BROWSER_NAME is not specified"));
                
                if (browserName.ToLower().Equals("chrome"))
               
                    return new ChromeDriver();
                
                    return new FirefoxDriver();
                
           
            
        }
    }
}
