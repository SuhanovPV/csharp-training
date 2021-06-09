using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //===========================
            System.Console.WriteLine("ContactModificationTest: Contact modification test started");
            int index = 0;
            ContactData newContact = new ContactData("NewName", "NewLastName");
            newContact.Nickname = "NewNickName";
            newContact.Group = "ZZZ";

            if (app.Contacts.IsContactListEmpty())
            {
                app.Contacts.Create(new ContactData("", ""));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldDate = oldContacts[index];

            app.Contacts.Modify(index, newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

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