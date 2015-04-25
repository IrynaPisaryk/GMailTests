using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class LetterHandler
    {
        private IWebDriver driver;
        private LetterPage page;

        public LetterHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new LetterPage(driver);
        }

        public LogoutHandler SendLetterIntoSpam()
        {
            page.GetAltMenu();
            page.SendIntoSpam();
            return new LogoutHandler(driver);
        }

        public bool IsEmoticonsPresentsInLetterText()
        {
            return page.GetLetterText();
        }

    }
}
