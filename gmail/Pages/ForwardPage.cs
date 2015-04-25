using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail.Pages
{
    public class ForwardPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@act='add']")]
        private IWebElement addForwardAdress;

        public ForwardPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void TapIntoAddForwardAdressButton()
        {
            addForwardAdress.Click();
        }
    }
}
