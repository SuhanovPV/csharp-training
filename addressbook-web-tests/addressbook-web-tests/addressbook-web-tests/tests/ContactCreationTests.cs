using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDateProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    MiddleName = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Title =GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Address = GenerateRandomString(200),
                    HomePhone = GenerateRandomPhone(),
                    MobilePhone = GenerateRandomPhone(),
                    WorkPhone = GenerateRandomPhone(),
                    Fax = GenerateRandomPhone(),
                    Email = GenerateRandomString(40),
                    Email2 = GenerateRandomString(40),
                    Email3 = GenerateRandomString(40),
                    Homepage = GenerateRandomString(100),
                    Bday = GenerateRandomDay(),
                    Bmonth = GenerateRandomMonth(),
                    Byear = GenerateRandomYear(),
                    Aday = GenerateRandomDay(),
                    Amonth = GenerateRandomMonth(),
                    Ayear = GenerateRandomYear(),
                    Group = "ForContacts",
                    Address2 = GenerateRandomString(200),
                    Phone2 = GenerateRandomPhone(),
                    Notes = GenerateRandomString(40)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile() 
        {
            return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile() 
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreationTest(ContactData contact)
        {
            

            if (app.Groups.IsGroupPresent(contact.Group)) 
            {
                app.Groups.Create(new GroupData(contact.Group));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
