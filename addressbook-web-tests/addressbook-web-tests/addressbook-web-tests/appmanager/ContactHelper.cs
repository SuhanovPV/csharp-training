using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            string homePage = "";
            if (cells[9].FindElements(By.TagName("a")).Count > 0)
            {
                homePage = cells[9].FindElement(By.TagName("a")).GetAttribute("href");
            }
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
                Homepage = homePage

            };
        }

        public String GetContactInformationFromCard(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactCard(index);
            string text = driver.FindElement(By.Id("content")).Text;
            return text;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).Text;

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).Text;
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).Text;

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Bday = bDay, 
                Bmonth = bMonth,
                Byear = bYear,
                Aday = aDay,
                Amonth = aMonth,
                Ayear = aYear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }

        private List<ContactData> contactCache = null;

        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            InitContactRemoval();
            ConfirmContactRemoval();
            manager.Navigator.HomePage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newContact)
        {
            InitContactModification(index);
            FillContactForm(newContact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            SelectFile(By.Name("photo"), contact.PhotoPath);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            SelectValue(By.Name("bday"), contact.Bday);
            SelectValue(By.Name("bmonth"), contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            SelectValue(By.Name("aday"), contact.Aday);
            SelectValue(By.Name("amonth"), contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            if (IsElementPresent(By.Name("new_group")))
            {
                SelectValue(By.Name("new_group"), contact.Group);
            }
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null) 
            {
                manager.Navigator.GoToHomePage();
                contactCache = new List<ContactData>() { };
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    String firsName = element.FindElement(By.XPath(".//td[3]")).Text;
                    String lastName = element.FindElement(By.XPath(".//td[2]")).Text;
                    contactCache.Add(new ContactData(firsName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    }) ;
                }

            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index  + 1) + "]/..")).Click();
            return this;
        }

        public ContactHelper GoToContactCard(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Details'])[" + (index + 1) + "]/..")).Click();
            return this;
        }

        public bool IsContactListEmpty() 
        {
            manager.Navigator.GoToHomePage();
            return !IsElementPresent(By.XPath("//input[@name='selected[]']"));
        }
    }
}
