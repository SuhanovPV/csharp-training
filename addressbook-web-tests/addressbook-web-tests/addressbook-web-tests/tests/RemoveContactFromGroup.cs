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
            List<GroupData> allGroups = GroupData.GetAll();
            List<ContactData> allContacts = ContactData.GetAll();

            GroupData testGroup = null;

            if (allGroups.Count == 0)
            {
                app.Groups.Create(new GroupData("test_group"));
            } 
            else if (allGroups.Count > 0)
            {
                foreach (GroupData group in GroupData.GetAll())
                {
                    if (group.GetContacts().Count != 0)
                    {
                        testGroup = group;
                        break;
                    }
                }
            }

            if (allContacts.Count == 0)
            {
                app.Contacts.Create(new ContactData("name", "lastname"));
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
