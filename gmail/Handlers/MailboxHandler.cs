using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMail.Pages;
using OpenQA.Selenium;
using System.Resources;
using System.Reflection;

namespace GMail.Handlers
{
    public class MailboxHandler
    {
        private IWebDriver driver;
        private MailboxPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public String theme { get; set; }
        public String text { get; set; }

        public MailboxHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new MailboxPage(driver);
        }
        
        public LogoutHandler SendLetterToUser() 
        {           
            page.TapIntoWriteButton();
            page.SetAdress(rm.GetString("adressSecondUser"));            
            theme = page.SetTheme();            
            text = page.SetText();
            page.TapIntoSendButton();
            return new LogoutHandler(driver);
        }

        public AttachHandler SendBigLetterToUser()
        {
            page.TapIntoWriteButton();
            page.SetAdress(rm.GetString("adressSecondUser"));
            page.SetTheme();
            page.SetText();
            return new AttachHandler(driver);
        }

        public EmoticonHandler SendLetterWithEmoticonToUser()
        {
            page.TapIntoWriteButton();
            page.SetAdress(rm.GetString("adressFirstUser"));
            theme = page.SetTheme();            
            return new EmoticonHandler(driver);
        }

        public MailboxHandler TapIntoSendButton()
        {
            page.TapIntoWriteButton();
            return new MailboxHandler(driver);
        }

        public MailboxHandler TapIntoPaperclipButton()
        {
            page.TapIntoPaperClipButton();
            return new MailboxHandler(driver);
        }

        public MailboxHandler SetAdress()
        {
            page.SetAdress(rm.GetString("adressSecondUser")); 
            return new MailboxHandler(driver);
        }

        public LetterHandler GetLetter(String theme="", String text="")
        {
            if (!theme.Equals("") && !text.Equals(""))
            {
                page.ClickIntoSentMessage(theme.Remove(0, 1), text.Remove(0, 1));
            }
            else if (!theme.Equals("") && text.Equals(""))
            {
                page.ClickIntoSentMessage(theme.Remove(0, 1), text);
            }
            else
            {
                page.ClickIntoSentMessage(theme, text);
            }
            return new LetterHandler(driver);
        }

        public SpamHandler MoveIntoSpam()
        {
            page.TapIntoMoreButton();
            page.TapIntoSpamField();
            return new SpamHandler(driver);
        }

        public SettingsHandler MoveIntoSettings()
        {
            page.TapIntoSettingsButton();
            page.TapIntoSettingsMenu();
            return new SettingsHandler(driver);
        }

        public bool IsNewLetterDialogAppear()
        {
            return page.IsNewLetterDialogExist();           
        }

        public ShortcutHandler GetShotcutDialog()
        {
            page.TapIntoTriangleButton();
            return new ShortcutHandler(driver);
        }

        public bool IsNewShortcutExist()
        {
            return page.IsNewShortcutExist();
        }
    }
}
