using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class ThemesPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//img[@src='//ssl.gstatic.com/ui/v1/icons/mail/themes/beach2/preview.png']")]
        private IWebElement beachTheme;

        public ThemesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void TapIntoBeachTheme()
        {
            beachTheme.Click();
        }
    }
}
