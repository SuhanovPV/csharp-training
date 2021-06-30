using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        { 
            int index = 0;
            ContactData newContact = new ContactData("NewName", "NewLastName");
            newContact.Nickname = "NewNickName";
            newContact.Group = "ZZZ";

            if (app.Contacts.IsContactListEmpty())
            {
                app.Contacts.Create(new ContactData("", ""));
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldDate = oldContacts[index];

            app.Contacts.Modify(oldDate.Id, newContact);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[index].Name = newContact.Name;
            oldContacts[index].LastName = newContact.LastName;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts) 
            {
                if (contact.Id ==oldDate.Id) 
                {
                    Assert.AreEqual(newContact.Name, contact.Name);
                    Assert.AreEqual(newContact.LastName, contact.LastName);
                }
            }

        }
    }
}