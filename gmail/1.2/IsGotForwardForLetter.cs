using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Resources;
using System.Reflection;
using GMail.Handlers;

namespace GMail._1._2
{
    [TestFixture]
	public class IsGotForwardForLetter
	{

        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private LogoutHandler logoutPage;
        private LetterHandler letterPage;
        private MailboxHandler mailboxPage;
        private ForwardAlterDialogHandler forwardAlterPage;
        private ForwardHandler forwardPage;
        private SettingsHandler settingsPage;

        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
        }

        [Test]
        public void _Step_A_LoginSecondUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressSecondUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_B_MoveIntoSettings()
        {
            settingsPage = mailboxPage.MoveIntoSettings();
        }


        [Test]
        public void _Step_C_MoveIntoFofward()
        {
            forwardPage = settingsPage.GetForward();
        }

        [Test]
        public void _Step_D_SetForwardAdress()
        {
            forwardAlterPage = forwardPage.GetForwardAdressMenu();
        }

        [Test]
        public void _Step_E_SetFofwardParams()
        {
            logoutPage = forwardAlterPage.SetChangesAndConfirmChoice(rm.GetString("adressThirdUser"));
        }

        [Test]
        public void _Step_F_LogoutSecondUser()
        {
            loginPage = logoutPage.LogoutUser();
        }

        [Test]
        public void _Step_G_LoginThirdUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressThirdUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_H_ConfirmForward()
        {
            letterPage = mailboxPage.GetLetter();
        }

        //todo

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
	}
}
