using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace GMail.Pages
{
    public class LetterPage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@act='9']/img[@class='dS J-N-JX']")]
        private IWebElement intoSpam;

        [FindsBy(How = How.XPath, Using = "//img[@class='hA T-I-J3']")]
        private IWebElement altMenu;

        [FindsBy(How = How.XPath, Using = "//div[@id=':dq']/a[4]")]
        private IWebElement confrmReference;

        [FindsBy(How = How.XPath, Using = "//div[@dir='ltr']")]
        private IWebElement letterText;

        public LetterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);  
        }

        public void GetAltMenu()
        {
            altMenu.Click();
        }

        public void SendIntoSpam()
        {
            intoSpam.Click();
        }

        public bool GetLetterText()
        {
            ReadOnlyCollection<IWebElement> allEmoticons = driver.FindElements(By.XPath("//div[@dir='ltr']/img"));
            List<IWebElement> collection = allEmoticons.ToList();

            string[] arrayOfEmoticonsID = new string[] { "330", "35D", "1A5"};

            int flagP = 0;
            int flagN = 0;
            
            foreach(IWebElement item in collection)
            {
                for(int i = 0; i < arrayOfEmoticonsID.Length; i++)
                {
                    if (item.GetAttribute("goomoji").Equals(arrayOfEmoticonsID[i]))
                    {
                        flagP++;
                    }
                    else flagN++;                    
                }                
            }

            if (flagP == arrayOfEmoticonsID.Length)
            {
                return true;
            }
            return false;
        }

    }
}
