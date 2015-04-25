using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class SpamHandler
    {
        private IWebDriver driver;
        private SpamPage page;

        public SpamHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new SpamPage(driver);
        }

        public Boolean IsCurrentLetterInSpam(String theme, String text)
        {
            return page.IsSentMessage(theme, text);
        }
    }
}
