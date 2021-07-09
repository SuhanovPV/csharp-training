﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig() 
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open)) 
            {
                app.Ftp.Upload("/config_inc.php", localFile); 
            }
             
           
        }
        
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData() 
            { 
                Name = "testuser",
                Password = "password",
                Email = "testuser1@loacalhost.localdomain" 
            };

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig() 
        {
            app.Ftp.RestoreBackUpFile("/config_inc.php");
        }
    }
}
