using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class LogoutHandler
    {
        private IWebDriver driver;
        private LogoutPage page;

        public LogoutHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new LogoutPage(driver);
        }

        public LoginHandler LogoutUser()
        {           
            page.TapIntoAccountsButton();
            page.LogoutUser();
            return new LoginHandler(driver);
        }
    }
}
