using AutomatingLinkedIn.Ilistner_ScreenShot;
using AutomatingLinkedIn.Credentials;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomatingLinkedIn.Base_Class
{
  public  class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement Userid;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//button[@type = 'submit']")]
        public IWebElement SignIn;

        public void Login()
        {
            CredentialsData credentials = new CredentialsData();
            Userid.SendKeys(credentials.email);
            Password.SendKeys(credentials.password);
            SignIn.Click();
            Ilistiner ilistiner = new Ilistiner(driver);
            // Log.info("My Account link element found");
            Thread.Sleep(500);
            ilistiner.ScreenShot();
        }
    }
}
