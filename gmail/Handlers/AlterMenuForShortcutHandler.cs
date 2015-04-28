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
    public class AlterMenuForShortcutHandler
    {
        private IWebDriver driver;
        private AlterShortcutPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public AlterMenuForShortcutHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new AlterShortcutPage(driver);
        }

        public MailboxHandler CreateNewShortcut()
        {
            page.SetNewShortcutName(rm.GetString("shortcutName"));
            page.TapIntoCreateButton();
            return new MailboxHandler(driver);
        }
    }
}
