using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemoval() 
        {
            int index = 0;
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (oldContacts.Count == 0) 
            {
                app.Contacts.Add(new ContactData()
                {
                    FirstName = "fname",
                    LastName = "lname",
                });

                oldContacts = app.Contacts.GetContactList();
            }

            app.Contacts.RemoveContactAtIndex(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
