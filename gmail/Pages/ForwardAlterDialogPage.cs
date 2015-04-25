using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail.Pages
{
    public class ForwardAlterDialogPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']//input[@type='text']")]
        private IWebElement alterMenu;

        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD-Jl']/button[@name='next']")]
        private IWebElement nextButton;


        [FindsBy(How = How.XPath, Using = "//input[@type='submit'][@value='Продолжить']")]
        private IWebElement confirmForwardAdress;

        [FindsBy(How = How.XPath, Using = "//button[@name='ok']")]
        private IWebElement okButton;

        public ForwardAlterDialogPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SetAdress(string adress)
        {
            alterMenu.SendKeys(adress);
        }

        public void TapIntoNextButton()
        {
            nextButton.Click();
        }

        public void TapIntoConfirmForwardAdressButton()
        {
            IWebElement containerFrame = driver.FindElement(By.XPath("//iframe[@class='ds']"));
            driver.SwitchTo().Frame(containerFrame);
            confirmForwardAdress.Click();
        }

        public void TapIntoOkButton()
        {
            okButton.Click(); 
        }
    }
}
