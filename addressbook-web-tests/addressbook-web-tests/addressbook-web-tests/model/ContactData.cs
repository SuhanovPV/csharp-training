using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string photoPath;
        private string allPhones;
        private string allEmails;

        public ContactData() 
        {
        }

        public ContactData(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Name.CompareTo(other.Name) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return (Name + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("ContactData ({0}): {1} {2}", Id, Name, LastName);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (Name == other.Name)
            {
                if (LastName == other.LastName)
                {
                    return true;
                }
            }
            return false;
        }

        private string LineFeedAdder(string text)
        {
            if (text == null || text == "")
            {
                return text;
            }
            return text + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return null;
            }
            return LineFeedAdder(Regex.Replace(phone, "[ -()]", ""));
        }

        public string PhoneCardFormat(string phone, string letter)
        {
            if (phone == null || phone == "")
            {
                return phone;
            }
            return String.Format("{0}: {1}", letter, CleanUp(phone));
        }

        private string SpaseAdder(string text)
        {
            if (text == null || text == "")
            {
                return text;
            }
            return text + " ";
        }

        private DateTime ConvertToDate(string year, string month, string day)
        {
            if (day == null || day == "" || day == "0" || day == "-") 
            {
                day = "1";
            }
            
            return new DateTime(Int32.Parse(year), GetMonth(month), Int32.Parse(day));
        }

        private string CardDateFormat(string year, string month, string day, string value) 
        {
            string result = "";
            if (day != null && day != "" && day != "0" && day != "-") 
            {
                result += day + ".";
            }
            if (month != null && month != "" && month != "0" && month != "-")
            {
                result += " " + month + " ";
            }
            if (year != null && year != "" && year != "0" && year != "-")
            {
                result += year + " (" + GetYearSinceDate(ConvertToDate(year, month, day)) + ")";
            }
            if (result != "") 
            {
                return (value + " " + result + "\r\n").Replace("  "," ");
            }
            return result;
        }

        private int GetYearSinceDate(DateTime date) 
        {
            DateTime now = DateTime.Today;
            int diffYears = now.Year - date.Year;
            if (date.Month == now.Month && now.Day < date.Day)
            {
                diffYears--;
            }
            else if (now.Month < date.Month) 
            {
                diffYears--;
            }
            return diffYears;
        }

        private int GetMonth(string month) 
        { 
            switch (month) 
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 1;
            }
        }

        [Column(Name = "firstname"), NotNull]
        public string Name { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string MiddleName { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "nickname"), NotNull]
        public string Nickname { get; set; }
        
        public string PhotoPath
        {
            get
            {
                if (String.IsNullOrEmpty(photoPath))
                {
                    return photoPath;
                }
                else 
                {
                    return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + photoPath;
                }
            }
            set
            {
                photoPath = value;
            }
        }

        [Column(Name = "title"), NotNull]
        public string Title { get; set; }

        [Column(Name = "company"), NotNull]
        public string Company { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkPhone { get; set; }

        [Column(Name = "mobile"), NotNull]
        public string MobilePhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        [Column(Name = "fax"), NotNull]
        public string Fax { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
        public string Email3 { get; set; }
        
        public string AllEmails 
        {
            get 
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else 
                {
                    return (LineFeedAdder(Email) + LineFeedAdder(Email2) + LineFeedAdder(Email3)).Trim();
                }
            }
            set 
            {
                allEmails = value;
            }
        }

        [Column(Name = "homepage"), NotNull]
        public string Homepage { get; set; }

        [Column(Name = "bday"), NotNull]
        public string Bday { get; set; }

        [Column(Name = "bmonth"), NotNull]
        public string Bmonth { get; set; }

        [Column(Name = "byear"), NotNull]
        public string Byear { get; set; }

        [Column(Name = "aday"), NotNull]
        public string Aday { get; set; }

        [Column(Name = "amonth"), NotNull]
        public string Amonth { get; set; }

        [Column(Name = "ayear"), NotNull]
        public string Ayear { get; set; }

        public string Group { get; set; }

        [Column(Name = "address2"), NotNull]
        public string Address2 { get; set; }

        [Column(Name = "phone2"), NotNull]
        public string Phone2 { get; set; }

        [Column(Name = "notes"), NotNull]
        public string Notes { get; set; }

        public string FullName 
        {
            get 
            {
                return (SpaseAdder(Name) + SpaseAdder(MiddleName) 
                    + SpaseAdder(LastName)).Trim();
            }
        }

        public string CardFormat
        {
            get 
            {
                return (LineFeedAdder(FullName)
                    + LineFeedAdder(Nickname)
                    + "\r\n"
                    + LineFeedAdder(Title)
                    + LineFeedAdder(Company)
                    + LineFeedAdder(Address)
                    + "\r\n"
                    + PhoneCardFormat(HomePhone, "H")
                    + PhoneCardFormat(MobilePhone, "M")
                    + PhoneCardFormat(WorkPhone, "W")
                    + PhoneCardFormat(Fax, "F")
                    + "\r\n"
                    + LineFeedAdder(Email)
                    + LineFeedAdder(Email2)
                    + LineFeedAdder(Email3)
                    + "\r\n"
                    + CardDateFormat(Byear, Bmonth, Bday, "Birthday")
                    + CardDateFormat(Ayear, Amonth, Aday, "Anniversary")
                    + "\r\n"
                    + LineFeedAdder(Address2)
                    + "\r\n"
                    + PhoneCardFormat(Phone2, "P")
                    + "\r\n"
                    + LineFeedAdder(Notes)
                    + "\r\n").Trim();
            }
        }

        [Column(Name= "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
