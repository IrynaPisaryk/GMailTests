using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class ForwardHandler
    {
        private IWebDriver driver;
        private ForwardPage page;

        public ForwardHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new ForwardPage(driver);
        }

        public ForwardAlterDialogHandler GetForwardAdressMenu()
        {
            page.TapIntoAddForwardAdressButton();
            return new ForwardAlterDialogHandler(driver);
        }
    }
}
