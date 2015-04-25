using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;

namespace GMail.DriverAdapter
{
    public sealed class Adapter
    {
        private static IWebDriver instance;
        private static ResourceManager rm = new ResourceManager("GMail.gmail", Assembly.GetExecutingAssembly());

        private Adapter() { }

        public static IWebDriver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FirefoxDriver();
                    SetUpInstanceParameters();
                    return instance;
                }
                return null;
            }
            set
            {                
                instance = null;
            }
        }

        private static void SetUpInstanceParameters()
        {           
            instance.Navigate().GoToUrl(rm.GetString("URL", CultureInfo.InvariantCulture));      
            instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(500)); 
        }       
    }
}
