using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail.Pages
{
    public class SettingsPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/#settings/fwdandpop']")]
        private IWebElement forwardingAndPOPIMAP;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/#settings/themes']")]
        private IWebElement themes;

        public SettingsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void TapIntoForwardProperty()
        {
           forwardingAndPOPIMAP.Click();             
        }

        public void TapIntoThemeTab()
        {
            themes.Click();
        }
    }
}
