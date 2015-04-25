using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement emailArea;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement passwordArea;

        [FindsBy(How = How.Id, Using = "PersistentCookie")]
        private IWebElement rememberUserBox;

        [FindsBy(How = How.Id, Using = "signIn")]
        private IWebElement signInButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void SetEmail(string adress)
        {
            emailArea.SendKeys(adress);
        }

        public void SetPassword(string password)
        {
            passwordArea.SendKeys(password);
        }

        public void SetSelectBoxToDoNotrememberUserCredentials()
        {
            if (rememberUserBox.Selected) 
                { 
                    rememberUserBox.Click(); 
                }
        }

        public void SignIn()
        {
            signInButton.Click();
        }
    }
}
