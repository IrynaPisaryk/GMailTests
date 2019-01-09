using GMail.Handlers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GMail._1._10
{
    public class IsShortcutsDeleted
    {

        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private ShortcutHandler shortcutPage;
        private AlterMenuForShortcutHandler alterShortcutPage;

        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
            mailboxPage = loginPage.LoginUser(rm.GetString("adressFirstUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_A_ShotcutDialog()
        {
            shortcutPage = mailboxPage.PrepareToDeleteShortcuts();
        }

        [Test]
        public void _Step_B_PrepareToDelete()
        {
            mailboxPage = shortcutPage.DeleteShortcuts();
        }
        
        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
