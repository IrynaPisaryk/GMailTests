using GMail.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Handlers
{
    public class LoginHandler
    {
        private IWebDriver driver;
        private LoginPage page;

        public LoginHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new LoginPage(driver);
        }

        public MailboxHandler LoginUser(string adress, string password)
        {            
            page.SetEmail(adress);
            page.SetPassword(password);
            page.SetSelectBoxToDoNotrememberUserCredentials();
            page.SignIn();
            return new MailboxHandler(driver);
        }
    }
}
