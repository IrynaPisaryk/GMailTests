using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class ShortcutColourDialogPage : BasePage
    {
         private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@id=':cc.sub'][@name=':cc.radio']")]
        private IWebElement AllShortcutsButton;

        [FindsBy(How = How.XPath, Using = "//button[text()='Настроить цвет']")]
        private IWebElement SetUpColourButton;

        public ShortcutColourDialogPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SelectAllShortcut()
        {
            AllShortcutsButton.Click();
        }

        public void ChooseColour()
        {
            SetUpColourButton.Click();
        }
    }
}
