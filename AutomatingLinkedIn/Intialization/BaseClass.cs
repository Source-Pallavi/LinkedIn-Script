using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Intialization
{
   public class BaseClass
    {
        public IWebDriver driver;
        ExtentReports report;
        ExtentTest _test;
        public string browser;
        [OneTimeSetUp]
        public void Setup()
        {

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.linkedin.com/login";
            report = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\extent.html");
            report.AttachReporter(htmlReporter);
        }
        [TearDown]
        public void AfterTest()
        {
            _test = report.CreateTest(TestContext.CurrentContext.Test.Name);

            var status = TestContext.CurrentContext.Result.Outcome.Status; 
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            { 

                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    _test.Log(logstatus, "Test ended with " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    _test.Log(logstatus, "Test ended with " + logstatus);
                    break;
            }

            report.Flush();

        }
    }
}
