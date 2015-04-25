using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using GMail.Pages;

namespace GMail.Handlers
{
    public class ForwardAlterDialogHandler
    {
        private IWebDriver driver;
        private ForwardAlterDialogPage page;

        public ForwardAlterDialogHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new ForwardAlterDialogPage(driver);
        }

        public LogoutHandler SetChangesAndConfirmChoice(String adress)
        {
            page.SetAdress(adress);
            page.TapIntoNextButton();
            page.TapIntoConfirmForwardAdressButton();
            page.TapIntoOkButton();
            return new LogoutHandler(driver);
        }

    }
}
