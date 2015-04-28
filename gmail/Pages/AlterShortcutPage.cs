using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class AlterShortcutPage : BasePage
    {
         private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@class='xx']")]
        private IWebElement NewShortcutName;

        [FindsBy(How = How.XPath, Using = "//button[@class='J-at1-auR'][text()='Создать']")]
        private IWebElement CreateButton;

        public AlterShortcutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SetNewShortcutName(string newName)
        {
            NewShortcutName.SendKeys(newName);
        }

        public void TapIntoCreateButton()
        {
            CreateButton.Click();
        }
        
    }
}
