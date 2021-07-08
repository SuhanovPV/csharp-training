using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public void Add(ContactData contact)
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            Window form = manager.MainWindow.ModalWindow("Contact Editor");
            FillContactForm(contact, form);

            form.Get<Button>("uxSaveAddressButton").Click();
        }

        public void FillContactForm(ContactData contact, Window form)
        {
            DateTime date = new DateTime(2015,4,5);
            //TypeTextBox(form, "ueIdentifierAddressTextBox", contact.Identifier);
            //TypeTextBox(form, "ueTitleAddressTextBox", contact.PersonalTitle);
            TypeTextBox(form, "ueFirstNameAddressTextBox", contact.FirstName);
            //TypeTextBox(form, "ueMiddleNameAddressTextBox", contact.MiddleName);
            //TypeTextBox(form, "ueLastNameAddressTextBox", contact.LastName);
            //form.Get<DateTimePicker>("ueBirthDayDateTimePicker").GetElement(
            
            form.Get<DateTimePicker>("ueBirthDayDateTimePicker").SetDate(date, DateFormat.);
            //TypeTextBox(form, "uePhone1AddressTextBox", contact.Phone1);
            //TypeTextBox(form, "uePhone2AddressTextBox", contact.Phone2);
            //TypeTextBox(form, "ueFaxAddressTextBox", contact.Fax);
            //TypeTextBox(form, "ueMobile1AddressTextBox", contact.Mobile1);
            //TypeTextBox(form, "ueMobile2AddressTextBox", contact.Mobile2);
            //TypeTextBox(form, "ueWebAddressTextBox", contact.Web);
            //TypeTextBox(form, "ueEmail1AddressTextBox", contact.Email1);
            //TypeTextBox(form, "ueEmail2AddressTextBox", contact.Email2);

            //if (!String.IsNullOrEmpty(contact.CompanyName) || !String.IsNullOrEmpty(contact.AccountNumber)
            //    || !String.IsNullOrEmpty(contact.TaxNumber) || !String.IsNullOrEmpty(contact.RegisterNumber)) 
            //{
            //    form.Get<CheckBox>("uxIsCompanyGasCheckBox").Select();
            //    TypeTextBox(form, "ueCompanyAddressTextBox", contact.CompanyName);
            //    TypeTextBox(form, "ueAccountAddressTextBox", contact.AccountNumber);
            //    TypeTextBox(form, "ueTaxAddressTextBox", contact.TaxNumber);
            //    TypeTextBox(form, "ueRgisterAddressTextBox", contact.RegisterNumber);
            //}

            //TypeTextBox(form, "ueCountryAddressTextBox", contact.Address);
            //TypeTextBox(form, "ueStateAddressTextBox", contact.State);
            //TypeTextBox(form, "ueCityAddressTextBox", contact.Country);
            //TypeTextBox(form, "ueZipAddressTextBox", contact.Zip);
            //TypeTextBox(form, "ueAddressAddressTextBox", contact.Address);
            //TypeTextBox(form, "ueNoteAddressRichTextBox", contact.Note);

        }

        private void TypeTextBox(Window form, string identifier, string value)
        {
            if (!String.IsNullOrEmpty(value)) 
            {
                form.Get<TextBox>(identifier).Enter(value);
            }
            
        }
    }
}
