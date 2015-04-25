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

namespace GMail._1._7
{
    [TestFixture]
    public class SendLetterWithMeeting
    {
        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private ThemesHandler themesPage;
        private LetterHandler letterPage;
        private SettingsHandler settingsPage;
        private String theme;
        private String text;


        [TestFixtureSetUp]
        public void BeforeTests()
        {
            driver = DriverAdapter.Adapter.Instance;
            loginPage = new LoginHandler(driver);
        }

        public void _Step_A_LoginThirdUser()
        {
            mailboxPage = loginPage.LoginUser(rm.GetString("adressThirdUser"), rm.GetString("password"));
        }

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
