using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_project_tests
{
    public class LoginHelper: HelperBase
    {
        private string baseUrl;
        public LoginHelper(ApplicationManager manager, string baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public void Login(AccountData account)
        {
            if (LoggedIn()) 
            {
                if (LoggedIn(account)) 
                {
                    return;
                }
                LogOut();
            }

            FillLoginForm("username", account.Name);
            FillLoginForm("password", account.Password);
        }


        public bool LoggedIn()
        {
            return IsElementPresent(By.Id("navbar"));
        }

        public bool LoggedIn(AccountData account)
        {
            return LoggedIn() && GetUserName() == account.Name;
        }

        public void LogOut()
        {
            driver.Navigate().GoToUrl(baseUrl + "/logout_page.php");
        }

        private string GetUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }

        private void FillLoginForm(string field, string value)
        {
            driver.FindElement(By.Name(field)).SendKeys(value);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}
