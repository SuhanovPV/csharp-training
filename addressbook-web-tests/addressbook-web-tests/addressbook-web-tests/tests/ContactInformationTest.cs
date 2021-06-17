using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation() 
        {
            int index = 1;
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(index);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(index);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.Homepage, fromForm.Homepage);
        }

        [Test]
        public void TestCardInformation() 
        {
            int index = 1;
            String textFromCard = app.Contacts.GetContactInformationFromCard(index).Trim();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(index);
            
            //System.Console.WriteLine("==== TEXT FROM CARD ====");
            //System.Console.WriteLine(textFromCard.Length);
            //System.Console.WriteLine("==== TEXT TO CARD FORMAT ====");
            //System.Console.WriteLine(fromForm.CardFormat.Length);

            Assert.AreEqual(textFromCard, fromForm.CardFormat);            

        }
    }
}
