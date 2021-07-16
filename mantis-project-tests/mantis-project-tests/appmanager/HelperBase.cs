using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_project_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager) 
        {
            this.manager = manager;
            this.driver = manager.Driver;

        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SelectValue(By locator, string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                new SelectElement(driver.FindElement(locator)).SelectByText(text);
            }
        }

        public void Type(By locator, string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
    }
}
