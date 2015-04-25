using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Pages
{
    public class AttachFilePage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD'][@role='alertdialog']")]
        private IWebElement alterDialogToCreateBigFile;

        public AttachFilePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public bool IsAlterDialogExist()
        {
            if (alterDialogToCreateBigFile.Displayed)
            {
                return true;
            }
            return false;
        }


    }
}
