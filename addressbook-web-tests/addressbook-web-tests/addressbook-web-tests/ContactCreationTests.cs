using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            GoToAddContactPage();
            ContactData contact = new ContactData("testname");
            contact.LastName = "LName";
            contact.MiddleName = "MName";
            contact.Nickname = "NName";
            contact.PhotoPath = "\\pict\\pic.png";
            contact.Title = "TTtt";
            contact.Company = "OOO AAAA";
            contact.Address = "SPB";
            contact.HomePhone = "65421561";
            contact.MobilePhone = "924661561";
            contact.WorkPhone = "880054654";
            contact.Fax = "561651651";
            contact.Email = "mail.@gmail.com";
            contact.Email2 = "mail2.@gmail.com";
            contact.Email3 = "mail3.@gmail.com";
            contact.Homepage = "https://github.com/SuhanovPV/csharp-training";
            contact.Bday = "15";
            contact.Bmonth = "January";
            contact.Byear = "1984";
            contact.Aday = "1";
            contact.Amonth = "January";
            contact.Ayear = "1970";
            contact.Group = "ForContacts";
            contact.Address2 = "KLG";
            contact.Phone2 = "8616615";
            contact.Notes = "Notes";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            loginHelper.LogOut();
        }
    }
}
