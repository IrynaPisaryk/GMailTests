using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail.Pages
{
    public class LogoutPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://profiles.google.com/?hl=ru&tab=mX']")]
        private IWebElement accButton;

        [FindsBy(How = How.XPath, Using = "//a[@id='gb_71']")]
        private IWebElement logout;

        public LogoutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void TapIntoAccountsButton()
        {
            accButton.Click();
        }

        public void LogoutUser()
        {
            logout.Click();
        }

    }
}
