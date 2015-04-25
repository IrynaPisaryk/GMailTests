using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class SettingsHandler
    {
        private IWebDriver driver;
        private SettingsPage page;

        public SettingsHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new SettingsPage(driver);
        }

        public ForwardHandler GetForward()
        {
            page.TapIntoForwardProperty();
            return new ForwardHandler(driver);
        }

        public ThemesHandler GetThemes()
        {
            page.TapIntoThemeTab();
            return new ThemesHandler(driver);
        }
    }
}
