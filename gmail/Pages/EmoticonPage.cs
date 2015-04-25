using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMail.Pages
{
    public class EmoticonPage : BasePage
    {
        private IWebDriver driver;


        [FindsBy(How = How.XPath, Using = "//div[@class='QT aaA aMZ']")]
        private IWebElement emoticonIcon;

        [FindsBy(How = How.XPath, Using = "//div[@id=':12f.emo']")]
        private IWebElement emoticonMenu;

        //td[@id='J-Kw-cell-5846']/div[@goomoji='33E']/div

        [FindsBy(How = How.XPath, Using = "//div[@goomoji='35D']")]
        private IWebElement firstEmoticon;

        //div[@goomoji='32B'][@class='J-Kw-Jn-Zr']
        [FindsBy(How = How.XPath, Using = "//div[@goomoji='1A5']")]
        private IWebElement secondEmoticon;

        [FindsBy(How = How.XPath, Using = "//div[text()='Вставить']")]
        private IWebElement insertButton;
        
        public EmoticonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void TapIntoInsertButton()
        {          
            insertButton.Click();           
        }

        public void TapIntoEmoticonIcon()
        {
            emoticonIcon.Click();
        }

        public void SetEmoticons()
        {
            SendKeys.SendWait("+ 10");
            firstEmoticon.Click();
            secondEmoticon.Click();
        }
    }
}
