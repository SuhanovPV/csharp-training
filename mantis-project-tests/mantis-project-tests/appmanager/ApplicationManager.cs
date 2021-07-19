using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_project_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseUrl;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        protected LoginHelper loginHelper;
        protected ProjectManagementHelper projectManagerHelper;
        protected ManagementMenuHelper managementMenuHelper;
        protected APIHelper apiHelper;

        private ApplicationManager() 
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            baseUrl = "http://localhost/mantisbt-2.25.2";


            loginHelper = new LoginHelper(this, baseUrl);
            projectManagerHelper = new ProjectManagementHelper(this);
            managementMenuHelper = new ManagementMenuHelper(this, baseUrl);
            apiHelper = new APIHelper(this);
        }
        ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            { }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.MenuHelper.GoToMainPage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }

        public LoginHelper Auth 
        {
            get
            {
                return loginHelper;
            }
        }

        public ProjectManagementHelper Projects 
        {
            get 
            {
                return projectManagerHelper;
            }
        }

        public ManagementMenuHelper MenuHelper
        {
            get
            {
                return managementMenuHelper;
            }
        }

        public APIHelper API
        {
            get
            {
                return apiHelper;
            }
        }
    }
}
