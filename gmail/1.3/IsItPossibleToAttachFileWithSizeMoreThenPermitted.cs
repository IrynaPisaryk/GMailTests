using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Resources;
using System.Reflection;
using GMail.Handlers;
using NUnit.Framework;

namespace GMail._1._3
{
	public class IsItPossibleToAttachFileWithSizeMoreThenPermitted
	{       
        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private AttachHandler attachPage;
        private AlterDialogToAttachFileHandler alterAttachPage;


        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
        }

        [Test]
        public void _Step_A_LoginUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressFirstUser"), rm.GetString("password"));
        }


        [Test]
        public void _Step_B_CreateMessage()
        {
            attachPage = mailboxPage.SendBigLetterToUser();
        }

        [Test]
        public void _Step_C_AttachFile()
        {
            alterAttachPage = attachPage.AttachFile();
        }

        [Test]
        public void _Step_D_DidAttachFile()
        {
            Assert.True(alterAttachPage.IsSucessfulAttach());
        }

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
	}
}
