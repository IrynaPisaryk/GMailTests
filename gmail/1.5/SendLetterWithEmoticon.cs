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
using System.Windows.Forms;

namespace GMail._1._5
{
    [TestFixture]
    public class SendLetterWithEmoticon
    {
        private IWebDriver driver;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());
        private LoginHandler loginPage;
        private MailboxHandler mailboxPage;
        private EmoticonHandler emoticonPage;
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
        public void _Step_B_CreateLetterToSecondUser()
        {
            emoticonPage = mailboxPage.SendLetterWithEmoticonToUser();
            theme = mailboxPage.theme;
        }

        [Test]
        public void _Step_C_SetEmoticons()
        {
            mailboxPage = emoticonPage.SetEmoticons();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000)); 
        }

        [Test]
        public void _Step_D_TapIntoSendButton()
        {
            mailboxPage = mailboxPage.TapIntoSendButton();
            string windowName = driver.PageSource;
            driver.Navigate().Refresh();
        }

        [Test]
        public void _Step_E_GetSentLetter()
        {
            letterPage = mailboxPage.GetLetter(theme);
            
        }

        [Test]
        public void _Step_F_IsSentLetterContainsCorrectEmoticons()
        {
            Assert.True(letterPage.IsEmoticonsPresentsInLetterText());

        }

        [TestFixtureTearDown]
        public void AfterTests()
        {
            driver.Quit();
            DriverAdapter.Adapter.Instance = null;
        }
    }
}
