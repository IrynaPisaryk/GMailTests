using GMail.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Handlers
{
    public class EmoticonHandler
    {
        private IWebDriver driver;
        private EmoticonPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public EmoticonHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new EmoticonPage(driver);
        }

        public MailboxHandler SetEmoticons()
        {
            page.TapIntoEmoticonIcon();
            page.SetEmoticons();
            page.TapIntoInsertButton();
            return new MailboxHandler(driver);
        }

    }
}
