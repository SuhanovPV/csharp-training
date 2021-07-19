using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;
        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts() 
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = openAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement row in rows) 
            {
                IWebElement link =  row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData() { Name = name, Id = id });
            }

            return accounts;
        }

        public void DeleteAccount(AccountData account) 
        {
            Console.WriteLine("");
            IWebDriver driver = openAppAndLogin();
            Console.WriteLine("LoggedIN");
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            Console.WriteLine("Goes to: " + baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id);
            driver.FindElement(By.XPath("//form[@id='manage-user-delete-form']//span//input")).Click();
            driver.FindElement(By.CssSelector("input.btn")).Click();

        }

        private IWebDriver openAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            FillLoginForm(driver, "username", "administrator");
            FillLoginForm(driver, "password", "123");
            return driver;
        }

        private void FillLoginForm(IWebDriver driver, string field, string value)
        {
            driver.FindElement(By.Name(field)).SendKeys(value);
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }
    }
}
