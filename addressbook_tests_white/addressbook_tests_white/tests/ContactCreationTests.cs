using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            ContactData contact = new ContactData() 
            { 
                FirstName = "fname", 
                LastName = "lname" , 
                TaxNumber = "465135", 
                Bday = new DateTime(2015, 2, 10)
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Add(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
