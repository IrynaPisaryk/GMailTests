using GMail.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Handlers
{
    public class AlterDialogToAttachFileHandler
    {
        private IWebDriver driver;
        private AttachFilePage page;

        public AlterDialogToAttachFileHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new AttachFilePage(driver);
        }

        public bool IsSucessfulAttach()
        {
            return page.IsAlterDialogExist();
        }
    }
}
