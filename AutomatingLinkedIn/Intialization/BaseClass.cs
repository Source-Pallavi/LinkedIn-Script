using AventStack.ExtentReports.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Intialization
{
    class BaseClass
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {

            BrowserFactory fact = new BrowserFactory();
            driver = fact.InitBrowser("firefox");

            driver.Manage().Window.Maximize();
            driver.Url = Config.URL;

        }
    }
}
