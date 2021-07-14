using NUnit.Framework;
using System;
using OpaqueMail;

namespace mantis_tests.tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser5",
                Password = "password",
                Email = "testuser5@localhost.localdomain"
            };

            Pop3Client pop3 = new Pop3Client("localhost.localdomain", 110, account.Name, account.Password, false);
            pop3.Connect();
            pop3.Authenticate();

            int count = pop3.GetMessageCount();
            for (int i = 0; i < 5; i++)
            {
                if (pop3.GetMessageCount() > 0)
                {
                    MailMessage message = pop3.GetMessage(1);
                    System.Console.WriteLine("Done! " + message.Body);
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Assert.AreEqual(pop3.GetMessageCount(), 1);
        }
    }
}
