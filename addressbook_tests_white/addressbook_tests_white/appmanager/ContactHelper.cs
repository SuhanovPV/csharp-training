using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
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

        public void RemoveContactAtIndex(int index)
        {
            TableRows rows = manager.MainWindow.Get<Table>("uxAddressGrid").Rows;
            rows[index].Click();
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window dialogue = manager.MainWindow.ModalWindow("Question");
            //dialogue.Get<Button>("265298").Click();
            Button btn = (Button) dialogue.Get(SearchCriteria.ByText("Yes"));
            btn.Click();
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            TableRows rows = manager.MainWindow.Get<Table>("uxAddressGrid").Rows;

            foreach (TableRow row in rows)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = GetCellValue(row.Cells[0]),
                    LastName = GetCellValue(row.Cells[1]),
                    CompanyName = GetCellValue(row.Cells[2]),
                    City = GetCellValue(row.Cells[3]),
                    Address = GetCellValue(row.Cells[4]),
                });
            }

            return contacts;
        }

        public string GetCellValue(TableCell cell) 
        {
            string text = cell.Value.ToString();
            if (text == "(не определено)") 
            {
                return "";
            }
            return text;
        }

        public void FillContactForm(ContactData contact, Window form)
        {
            TypeTextBox(form, "ueIdentifierAddressTextBox", contact.Identifier);
            TypeTextBox(form, "ueTitleAddressTextBox", contact.PersonalTitle);
            TypeTextBox(form, "ueFirstNameAddressTextBox", contact.FirstName);
            TypeTextBox(form, "ueMiddleNameAddressTextBox", contact.MiddleName);
            TypeTextBox(form, "ueLastNameAddressTextBox", contact.LastName);

            form.Get<DateTimePicker>("ueBirthDayDateTimePicker").SetDate(contact.Bday, DateFormat.DayMonthYear);

            TypeTextBox(form, "uePhone1AddressTextBox", contact.Phone1);
            TypeTextBox(form, "uePhone2AddressTextBox", contact.Phone2);
            TypeTextBox(form, "ueFaxAddressTextBox", contact.Fax);
            TypeTextBox(form, "ueMobile1AddressTextBox", contact.Mobile1);
            TypeTextBox(form, "ueMobile2AddressTextBox", contact.Mobile2);
            TypeTextBox(form, "ueWebAddressTextBox", contact.Web);
            TypeTextBox(form, "ueEmail1AddressTextBox", contact.Email1);
            TypeTextBox(form, "ueEmail2AddressTextBox", contact.Email2);

            if (!String.IsNullOrEmpty(contact.CompanyName) || !String.IsNullOrEmpty(contact.AccountNumber)
                || !String.IsNullOrEmpty(contact.TaxNumber) || !String.IsNullOrEmpty(contact.RegisterNumber))
            {
                form.Get<CheckBox>("uxIsCompanyGasCheckBox").Select();
                TypeTextBox(form, "ueCompanyAddressTextBox", contact.CompanyName);
                TypeTextBox(form, "ueAccountAddressTextBox", contact.AccountNumber);
                TypeTextBox(form, "ueTaxAddressTextBox", contact.TaxNumber);
                TypeTextBox(form, "ueRgisterAddressTextBox", contact.RegisterNumber);
            }

            TypeTextBox(form, "ueCountryAddressTextBox", contact.Address);
            TypeTextBox(form, "ueStateAddressTextBox", contact.State);
            TypeTextBox(form, "ueCityAddressTextBox", contact.Country);
            TypeTextBox(form, "ueZipAddressTextBox", contact.Zip);
            TypeTextBox(form, "ueAddressAddressTextBox", contact.Address);
            TypeTextBox(form, "ueNoteAddressRichTextBox", contact.Note);

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
