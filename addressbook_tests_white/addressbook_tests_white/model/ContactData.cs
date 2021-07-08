using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitle { get; set; }
        public string Identifier { get; set; }
        public string Bday { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Web { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        public string TaxNumber { get; set; }
        public string RegisterNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Citi { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            return "Contact <" + FirstName + "; " + LastName + " > ";
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
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

            if (FirstName == other.FirstName)
            {
                if (LastName == other.LastName)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
