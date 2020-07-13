using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatingLinkedIn.PostArticle
{
   public  class Article
    {
        public IWebDriver driver;

        public Article(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'share-box-feed-entry__trigger t-16 t-black--light t-bold')]")]
        public IWebElement StartAPost;

        [FindsBy(How = How.XPath, Using = "//div[@class='ql-editor ql-blank']")]
        public IWebElement TalkAbout;

        [FindsBy(How = How.XPath, Using = "//body/div/div/div/div/div/div/div/button[1]/li-icon[1]//*[local-name()='svg']")]
        public IWebElement ClickOnPicUpload;

        [FindsBy(How = How.XPath, Using = "//span[text()='Done']")]
        public IWebElement DoneButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Post']")]
        public IWebElement PostButton;

        [FindsBy(How = How.XPath, Using = "//li[6]//div[1]//div[1]//button[1]//div[1]")]
        public IWebElement Me;

       /* [FindsBy(How = How.XPath, Using = "//a[text()='Sign out']")]
        public IWebElement SignOut;*/



        public void CreatePost()
        {
            StartAPost.Click();
            Thread.Sleep(1000);

            TalkAbout.SendKeys("Quality Automation Engineers");
            Thread.Sleep(1000);

            ClickOnPicUpload.Click();
            Thread.Sleep(1000);

            Process.Start(@"CC:\Users\rebel\source\repos\upload_x64");
            Thread.Sleep(1000);

            DoneButton.Click();
            Thread.Sleep(1000);

            PostButton.Click();
            Thread.Sleep(1000);

            Me.Click();
            Thread.Sleep(1000);

            //SignOut.Click();
        }
    }
}
