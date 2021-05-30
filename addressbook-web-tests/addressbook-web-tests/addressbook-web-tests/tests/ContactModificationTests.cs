﻿using System;
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
            ContactData newContact = new ContactData("NewName");
            newContact.LastName = "NewLastName";
            newContact.Nickname = "New NickName";
            newContact.Group = "ZZZ";

            app.Contacts.Modify(2, newContact);
        }
    }
}