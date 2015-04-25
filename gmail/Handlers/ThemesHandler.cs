using GMail.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Handlers
{
    public class ThemesHandler
    {
        private IWebDriver driver;
        private ThemesPage page;

        public ThemesHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new ThemesPage(driver);
        }

        public void GetBeachTheme()
        {
            page.TapIntoBeachTheme();
        }
    }
}
