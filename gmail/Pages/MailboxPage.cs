using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace GMail.Pages
{
    public class MailboxPage : BasePage
    {
        private IWebDriver driver;
        private String path;

        [FindsBy(How = How.XPath, Using = "//*[@class='z0']/*")]
        private IWebElement writeButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@dir='ltr']")]
        private IWebElement adressField;

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        private IWebElement themeField;

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        private IWebElement textField;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement sendButton;        

        [FindsBy(How = How.XPath, Using = "//span[@class='CJ']")]
        private IWebElement moreButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Спам']")]
        private IWebElement spamFolder;

        [FindsBy(How = How.XPath, Using = "//div[@class='Cr aqJ']/div[@class='G-Ni J-J5-Ji']/div[@id=':2m']")]
        private IWebElement settingsButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='ms']/div[@class='J-N-Jz']")]
        private IWebElement settingsMenu;

        [FindsBy(How = How.XPath, Using = "//div[@class='a1 aaA aMZ']")]
        private IWebElement AttachFileButton;


        public MailboxPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //Test1
        public void TapIntoWriteButton()
        {
            writeButton.Click();
        }

        public void SetAdress(string adress)
        {
            adressField.SendKeys(adress);
        }

        public String SetTheme()
        {
            String theme = getLetterFilling();
            themeField.SendKeys(theme);
            return theme;
        }

        public String SetText()
        {
            String text = getLetterFilling();
            textField.SendKeys(text);
            return text;
        }

        public void TapIntoSendButton()
        {
            sendButton.Click();
        }

        public void TapIntoMoreButton()
        {
            moreButton.Click();
        }

        public void TapIntoSpamField()
        {            
            spamFolder.Click();
        }

        public void ClickIntoSentMessage(String theme, String text)
        {
            IWebElement currentLetter = this.GetSentMessage(theme, text);
            if (currentLetter != null)
            {
                currentLetter.Click();
            }

        }

        public static string getLetterFilling(int size = 6)
        {
            Random rnd = new Random();
            char c = new char();
            string name = "";
            while (name.Length < size)
            {
                while (name.Contains(c.ToString()))
                {
                    c = (char)(rnd.Next(97, 122));
                }
                name += c;
            }
            return name;
        }

        public IWebElement GetSentMessage(String theme, String text)
        {
            ReadOnlyCollection<IWebElement> allLetters = driver.FindElements(By.XPath("//tr[@id][@class]"));
            List<IWebElement> collection = allLetters.ToList();

            IWebElement currentTheme;
            IWebElement currentText;

            foreach (IWebElement item in collection)
            {
                currentTheme = item.FindElement(By.XPath("//tr[@id][@class]//td[@tabindex='-1']//span[@id]"));
                currentText = item.FindElement(By.XPath("//tr[@id][@class]//td[@tabindex='-1']//span[@class]"));

                if (!theme.Equals("") && !text.Equals(""))
                {
                    string currParam = currentTheme.Text + currentText.Text;

                    if (currParam.Equals(theme + " - " + text))
                    {
                        return item;
                    }
                }
                else if(currentTheme.Text.StartsWith("(#"))
                {
                    return item;
                }
                else if (currentTheme.Text.Equals(theme))
                {
                     return item;
                }
            }
            return null;
        }

        //Test2

        public void TapIntoSettingsButton()
        {
            settingsButton.Click();
        }

        public void TapIntoSettingsMenu()
        {
            settingsMenu.Click();

        }

        //Test3
        public void AttachFile()
        {
            AttachFileButton.Click();
        }

        public void GenerateFile()
        {
            StreamWriter FW = new StreamWriter("FILE.txt", false);            
            int sizeOfFile = 30000000;
           
            for (int i = 0; i < sizeOfFile; i++)
            {               
                FW.Write("a");
            }
            FW.Close();
            path = Path.GetFullPath("FILE.txt");
        }

        public void LoadFile()
        {
            SendKeys.SendWait(@"" + path);
            SendKeys.SendWait(@"{Enter}");
        }
    }
}
