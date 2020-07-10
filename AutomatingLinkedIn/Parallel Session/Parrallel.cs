using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Parallel_Session
{
    class Parrallel
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
                    // implement code to start chrome driver session
                }
                if (browserName.ToLower().Equals("firefox"))
                {
                    // implement code to start firefox driver session
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
