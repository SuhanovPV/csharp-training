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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest() 
        {
            int index = 0;
            if (app.Contacts.IsContactListEmpty()) 
            {
                app.Contacts.Create(new ContactData("", ""));
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[index];

            app.Contacts.Remove(toBeRemoved.Id);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(index);

            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts) 
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
