using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Base_Class
{
   public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ember24")]
        public IWebElement AccountSetting;

        [FindsBy(How = How.Id, Using = "ember38")]
        public IWebElement Logout;

        public void LogOut()
        {
            AccountSetting.Click();
            Thread.Sleep(500);
            Logout.Click();
          /*  MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("abc@hotmailcom");
            mail.To.Add("abc@hotmail.com");
            mail.Subject = "Test Mail....";
            mail.Body = "Mail With Attachment";
            Attachment attachment;
            attachment = new Attachment("C://Users//rebel//source//repos//LinkedinScript//LinkedinScript//Reports//dashboard.html");*/
        }
    }
}
