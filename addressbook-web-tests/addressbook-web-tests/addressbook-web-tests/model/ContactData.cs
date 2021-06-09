using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string name;
        private string middleName;
        private string lastName = "";
        private string nickname;
        private string photoPath;
        private string title;
        private string company;
        private string address;
        private string homePhone;
        private string mobilePhone;
        private string workPhone;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;
        private string group;
        private string address2;
        private string phone2;
        private string notes;

        public ContactData(string name) 
        {
            this.name = name;
        }

        public ContactData(string name, string lastName) : this(name)
        {
            this.lastName = lastName;
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

        public override string ToString()
        {
            return "Contat -> first name: " + Name + ", last name " + LastName;
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
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
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string HomePhone
        {
            get
            {
                return homePhone;
            }
            set
            {
                homePhone = value;
            }
        }
        public string WorkPhone
        {
            get
            {
                return workPhone;
            }
            set
            {
                workPhone = value;
            }
        }
        public string MobilePhone
        {
            get
            {
                return mobilePhone;
            }
            set
            {
                mobilePhone = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

    }
}
