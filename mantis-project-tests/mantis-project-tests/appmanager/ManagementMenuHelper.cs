using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_project_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseUrl;
        public ManagementMenuHelper(ApplicationManager manager, string baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public void GoToMainPage() 
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void GoToProjectsControl()
        {
            if (!OnControlPage()) 
            {
                driver.Navigate().GoToUrl(baseUrl + "/manage_overview_page.php");
            }
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        private bool OnControlPage()
        {
            return driver.FindElement(By.CssSelector("ul.nav-list li.active span")).Text == "Управление";
        }
    }
}
