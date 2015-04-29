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

namespace GMail._1._6
{
    [TestFixture]
    public class IsUserThemeChange
    {

        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private ThemesHandler themesPage;
        private SettingsHandler settingsPage;

        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
        }

        [Test]
        public void _Step_A_LoginFistUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressFirstUser"), rm.GetString("password"));
        }

        [Test]
        public void _Step_B_GoToTheSettings()
        {
            settingsPage = mailboxPage.MoveIntoSettings();
        }

        [Test]
        public void _Step_C_GetTheme()
        {
            themesPage = settingsPage.GetThemes();
        }


        [Test]
        public void _Step_C_SetTheme()
        {
            themesPage.GetBeachTheme();
        }

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
