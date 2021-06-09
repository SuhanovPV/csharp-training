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
            int index = 0;
            if (app.Contacts.IsContactListEmpty()) 
            {
                app.Contacts.Create(new ContactData("", ""));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(index);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(index);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
