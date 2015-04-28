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

namespace GMail._1._9
{
    [TestFixture]
    public class IsBothShortcutHasSameColour
    {
        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private ShortcutHandler shortcutPage;
        private ShortcutColorDialogHandler shortcutColorPage;
        private SpamHandler spamPage;
        private String theme;
        private String text;

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
            shortcutPage = mailboxPage.GetShotcutDialog();
        }

        [Test]
        public void _Step_B_SetColour()
        {
            shortcutColorPage = shortcutPage.SetShortcutColour();
        }

        [Test]
        public void _Step_C_IsWriteColour()
        {
            mailboxPage = shortcutColorPage.SetColour();
        }


        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
