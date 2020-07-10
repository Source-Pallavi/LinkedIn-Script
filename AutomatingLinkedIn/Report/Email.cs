using AutomatingLinkedIn.Credentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.Report
{
  public  class Email
    {
        public void Send_Report_In_Mail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("pallavidubey0823@gmail.com");
            mail.To.Add("rishibodake@hotmail.com");

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            mail.Subject = "Automation Test Report_"+TimeAndDate;

            mail.Body = "Please find the attached report to get details.";

            // string actualPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Report"); //Reports should store in Test_Execution_Reports folder
            Attachment attachment1;
            attachment1 = new Attachment(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\index.html");
            //report.Flush();
            var mostRecentlyModified = Directory.GetFiles(@"C:\Users\rebel\source\repos\QuantityMesurement\AutomatingLinkedIn\AutomatingLinkedIn\Report\", "*.html")
            .Select(f => new FileInfo(f))
            .OrderByDescending(fi => fi.LastWriteTime)
            .First()
            .FullName;

            Attachment attachment;
            attachment = new Attachment(mostRecentlyModified);
            mail.Attachments.Add(attachment);
           // CredentialsData credentials = new CredentialsData();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("pallavidubey0823@gmail.com", "12respect34");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
