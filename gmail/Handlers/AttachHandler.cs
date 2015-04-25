using GMail.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GMail.Handlers
{
    public class AttachHandler
    {
        private IWebDriver driver;
        private MailboxPage page;
        private ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        public AttachHandler(IWebDriver driver)
        {
            this.driver = driver;
            page = new MailboxPage(driver);
        }

        public AlterDialogToAttachFileHandler AttachFile()
        {
            page.AttachFile();
            page.GenerateFile();
            page.LoadFile();
            return new AlterDialogToAttachFileHandler(driver);
        }        
    }
}
