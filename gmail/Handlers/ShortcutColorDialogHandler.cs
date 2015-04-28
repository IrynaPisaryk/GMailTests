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
    public class ShortcutColorDialogHandler
    {
        private IWebDriver driver;
        private ShortcutColourDialogPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public ShortcutColorDialogHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new ShortcutColourDialogPage(driver);
        }

        public MailboxHandler SetColour()
        {
            page.SelectAllShortcut();
            page.ChooseColour();
            return new MailboxHandler(driver);
        }
    }
}
