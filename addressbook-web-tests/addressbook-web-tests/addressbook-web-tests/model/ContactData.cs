using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string photoPath;
        private string allPhones;

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
            return (Name+LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "Contat (" + Id + ") first name: " + Name + ", last name " + LastName;
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

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "") 
            {
                return null;
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
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
    }
}
