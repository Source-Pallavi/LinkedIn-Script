using AutomatingLinkedIn.Base_Class;
using AutomatingLinkedIn.Report;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
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
  public  class LinkedIn
    {
        IWebDriver driver;
       ExtentReports report = null;
         ExtentTest _test=null;
         ExtentReports _extent;


        [OneTimeSetUp]
        public void Initial()
        {
           driver = new ChromeDriver();
            driver.Url = "https://www.linkedin.com/login";
            driver.Manage().Window.Maximize();
            report = new ExtentReports();
           var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\extent.html");
        //    htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
           report.AttachReporter(htmlReporter);
            //  htmlReporter.OnTestStarted("")
        // _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test]
        public void LoginTest()
        {
           var Feature = report.CreateTest<Feature>("LoginTest");
         //  var Senario = Feature.CreateMode <Senario>
           // ExtentTest test = report.CreateTest("LoginTest").Info("Test report for login");
            LoginPage page = new LoginPage(driver);
            page.Login();
          //  report.Flush();
           // test.Log(Status.Pass, "Login Succesfull");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("pallavidubey0823@gmail.com");
            mail.To.Add("rishibodake@hotmail.com");
            mail.Subject = "Test Mail....";
            mail.Body = "Mail With Attachment";
            Attachment attachment;
            attachment = new Attachment(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\index.html");
            //report.Flush();
            Email email = new Email();
            // email.Send_Report_In_Mail();

        }
        /*  [Test]
          public void AutoitTest()
          {
              Autoit page = new Autoit(driver);
              page.Autoitp();

          }*/

        [Test]
        public void LogOutTest()
        {
          ExtentTest test = report.CreateTest("LogOutTest").Info("Test report for logout");
            HomePage page = new HomePage(driver);
            page.LogOut();
           test.Log(Status.Pass, "Logout Successfull");


        }
        /*  [Test]
          public void Logger()
            {
             //   DOMConfigurator.configure("log4j.xml");

     Log.startTestCase("Selenium_Test_001");
               // Log log = new Log(driver);
    ;        }*/

        [TearDown]
        public void AfterTest()
        {
            _test = report.CreateTest(TestContext.CurrentContext.Test.Name);

            var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace =TestContext.CurrentContext.Result.StackTrace ;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                   
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " +logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " +logstatus);
                        break;
                }

            report.Flush();
        }
    }
}
