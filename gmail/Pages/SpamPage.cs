using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace GMail.Pages
{
    public class SpamPage : BasePage
    {
        private IWebDriver driver { get; set; }

        public SpamPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsSentMessage(string theme, string text)
        {
            ReadOnlyCollection<IWebElement> allLetters = driver.FindElements(By.XPath("//tr[@class='zA zE']"));
            List<IWebElement> collectionOfAllLetters = allLetters.ToList();

            IWebElement currentTheme;
            IWebElement currentText;

            foreach (IWebElement item in collectionOfAllLetters)
            {
                currentTheme = item.FindElement(By.XPath("//tr[@class='zA zE']/ td[@tabindex='-1']//span//*"));
                currentText = item.FindElement(By.XPath("//tr[@class='zA zE']/ td[@tabindex='-1']//span[@class]"));

                string currParam = currentTheme.Text + currentText.Text;

                if (currParam.Equals(theme + " - " + text))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
