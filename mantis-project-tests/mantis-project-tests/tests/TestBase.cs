using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project_tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        [SetUp]

        public void SetUpApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData(){ Name= "administrator", Password="123" });
        }
    }
}
