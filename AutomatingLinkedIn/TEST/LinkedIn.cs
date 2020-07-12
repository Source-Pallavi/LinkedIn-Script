using AutomatingLinkedIn.Base_Class;
using AutomatingLinkedIn.Intialization;
using AutomatingLinkedIn.Parallel_Session;
using AutomatingLinkedIn.Report;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Ilistner_ScreenShot
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [Parallelizable]
    public class LinkedIn : AutomationBase
    {
        IWebDriver driver;
        ExtentReports report = null;
        ExtentTest _test = null;


        /*  [OneTimeSetUp]
          public void Initial()
          {
              driver = new ChromeDriver();
              driver.Url = "https://www.linkedin.com/login";
              driver.Manage().Window.Maximize();
              report = new ExtentReports();
              var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\extent.html");
            //  htmlReporter.setTheme(Theme.Dark);

              //    htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
              report.AttachReporter(htmlReporter);

              //  htmlReporter.OnTestStarted("")
              // _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


          }*/
        public LinkedIn(string browserName)
        {
           driver= StartBrowser("firefox");
            driver = StartBrowser("chrome");
            //   driver.Url = "https://www.linkedin.com/login";
            //  driver.Manage().Window.Maximize();
            report = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\extent.html");
            report.AttachReporter(htmlReporter);


        }

        [Test, Order(1)]
        public void LoginTest()
        {
           
            LoginPage page = new LoginPage(driver);
            page.Login();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("pallavidubey0823@gmail.com");
            mail.To.Add("rishibodake@hotmail.com");
            mail.Subject = "Test Mail....";
            mail.Body = "Mail With Attachment";
            Email email = new Email();

        }
        
        [Test, Order(2)]
        public void LogOutTest()
        {
            HomePage page = new HomePage(driver);
            page.LogOut();
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
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    _test.Log(logstatus, "Test ended with " +logstatus + " – " +errorMessage);
                    break;
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
        [OneTimeTearDown]
        public void AfterTest2()
        {
            driver.Close();
            driver.Quit();

        }
    }
}
