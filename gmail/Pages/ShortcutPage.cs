using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class ShortcutPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[text()='Добавить вложенный ярлык']")]
        private IWebElement NewShortcutMenu;

        [FindsBy(How = How.XPath, Using = "//span[text()='Цвет ярлыка']")]
        private IWebElement SetColourMenu;

        [FindsBy(How = How.XPath, Using = "//div[@title='RGB (242, 178, 168)']")]
        private IWebElement SetColour;

        public ShortcutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void MoveIntoShortcutMenu()
        {
            NewShortcutMenu.Click();
        }


        public void GetColourMenu()
        {
            SetColourMenu.SendKeys("");
        }

        public void ChooseColour()
        {
            SetColour.Click();
        }
    }
}
