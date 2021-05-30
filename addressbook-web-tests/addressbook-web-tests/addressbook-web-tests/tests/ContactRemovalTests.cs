using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest() 
        {
            if (app.Contacts.IsContactListEmpty()) 
            {
                app.Contacts.Create(new ContactData("remove"));
            }
            app.Contacts.Remove(1);
        }
    }
}
