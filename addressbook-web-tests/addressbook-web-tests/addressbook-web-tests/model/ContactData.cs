using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string photoPath;
        private string allPhones;
        private string allEmails;

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

        public string Name { get; set; }
        
        public string Id { get; set; }

        public string MiddleName { get; set; }
        
        public string LastName { get; set; } 
        
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
        public string Title { get; set; }
        
        public string Company { get; set; }
        
        public string Address { get; set; }
        
        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

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

        public string Fax { get; set; }

        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
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

        public string Homepage { get; set; }
        
        public string Bday { get; set; }
        
        public string Bmonth { get; set; }

        public string Byear { get; set; }
        
        public string Aday { get; set; }
        
        public string Amonth { get; set; }
        
        public string Ayear { get; set; }
        
        public string Group { get; set; }
        
        public string Address2 { get; set; }
        
        public string Phone2 { get; set; }

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
    }
}
