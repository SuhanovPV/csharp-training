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

            ContactData newContact = new ContactData("NewName");
            newContact.LastName = "NewLastName";
            newContact.Nickname = "New NickName";
            newContact.Group = "ZZZ";
            System.Console.WriteLine("ContactModificationTest: Checking IsContactListEmpty");
            if (app.Contacts.IsContactListEmpty())

            {
                app.Contacts.Create(new ContactData("remove"));
            }
            System.Console.WriteLine("ContactModificationTest: start contact modifying");
            app.Contacts.Modify(1, newContact);
        }
    }
}