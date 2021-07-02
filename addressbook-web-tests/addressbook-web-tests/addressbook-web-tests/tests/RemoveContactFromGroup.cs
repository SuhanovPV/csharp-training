using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup() 
        {
            GroupData testGroup = null;

            // Find not empty group
            foreach (GroupData group in GroupData.GetAll()) 
            {
                if (group.GetContacts().Count != 0) 
                {
                    testGroup = group;
                    break;
                }
            }

            if (testGroup == null) 
            {
                testGroup = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], testGroup);
            }

            List<ContactData> oldContacts = testGroup.GetContacts();

            app.Contacts.RemoveContactFromGroup(oldContacts[0], testGroup);

            List<ContactData> newContacts = testGroup.GetContacts();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
