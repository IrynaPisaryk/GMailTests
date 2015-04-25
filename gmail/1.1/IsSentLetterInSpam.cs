using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using GMail.Pages;
using GMail.Handlers;
using System.Resources;
using System.Reflection;

namespace GMail._1._1
{
    [TestFixture]
    public sealed class IsSentLetterInSpam
    {
        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private LogoutHandler logoutPage;
        private LetterHandler letterPage;
        private SpamHandler spamPage;
        private String theme;
        private String text;

        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
        }

        [Test]
        public void _Step_A_LoginFirstUser()
        {   
            mailboxPage = loginPage.LoginUser(rm.GetString("adressFirstUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_B_SendLetterToSecondUser()
        {
            logoutPage = mailboxPage.SendLetterToUser();
            theme = mailboxPage.theme;
            text = mailboxPage.text; 
        }

        [Test]
        public void _Step_C_LogoutFirstUser()
        {
            loginPage = logoutPage.LogoutUser();
        }

        [Test]
        public void _Step_D_LoginSecondUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressSecondUser"), rm.GetString("password"));
        }


        [Test]
        public void _Step_E_GetSentLetter()
        {            
            letterPage = mailboxPage.GetLetter(theme, text);
        }

        [Test]
        public void _Step_F_SendLetterIntoSpam()
        {
            logoutPage = letterPage.SendLetterIntoSpam();
        }

        [Test]
        public void _Step_G_LogoutSecondUser()
        {
            loginPage = logoutPage.LogoutUser();
        }


        [Test]
        public void _Step_H_LoginFirstUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressFirstUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_I_SendLetterToSecondUser()
        {
            logoutPage = mailboxPage.SendLetterToUser();
            theme = mailboxPage.theme;
            text = mailboxPage.text;
        }

        [Test]
        public void _Step_J_LogoutFirstUser()
        {
            loginPage = logoutPage.LogoutUser();
        }

        [Test]
        public void _Step_K_LoginSecondUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressSecondUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_L_GoIntoSpam()
        {
            spamPage = mailboxPage.MoveIntoSpam();
        }

        [Test]
        public void _Step_M_IsNeededLetterInSpam()
        {
            Assert.True(spamPage.IsCurrentLetterInSpam(theme, text));
        }

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
