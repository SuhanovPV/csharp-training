 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> allGroups = GroupData.GetAll();
            List<ContactData> allContacts = ContactData.GetAll();

            
            GroupData testGroup = null;

            if (allGroups.Count == 0)
            {
                app.Groups.Create(new GroupData("test_group"));
            }

            if (allContacts.Count == 0)
            {
                app.Contacts.Create(new ContactData("name", "lastname"));
            }
            if (allGroups.Count > 0 && allContacts.Count > 0)
            {
                foreach (GroupData group in allGroups)
                {
                    if (group.GetContacts().Count < allContacts.Count)
                    {
                        testGroup = group;
                        break;
                    }
                }
            }


            if (testGroup == null) 
            {
                testGroup = GroupData.GetAll()[0];
                app.Contacts.Create(new ContactData("name1", "lastname1"));
            }
                        
            List<ContactData> oldList = testGroup.GetContacts();
            ContactData testContact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(testContact, testGroup);

            List<ContactData> newList = testGroup.GetContacts();
            oldList.Add(testContact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
