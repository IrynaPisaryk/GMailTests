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
    public class ShortcutHandler
    {
        private IWebDriver driver;
        private ShortcutPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public ShortcutHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new ShortcutPage(driver);
        }

        public AlterMenuForShortcutHandler GetNewShortcut()
        {
            page.MoveIntoShortcutMenu();
            return new AlterMenuForShortcutHandler(driver);
        }

        public ShortcutColorDialogHandler SetShortcutColour()
        {
            page.GetColourMenu();
            page.ChooseColour();
            return new ShortcutColorDialogHandler(driver);
        }

    }
}
