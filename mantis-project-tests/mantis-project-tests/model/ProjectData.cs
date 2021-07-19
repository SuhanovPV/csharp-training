using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string state;
        private string visibility;

        public ProjectData() { }

        public String Id { set; get; }

        public string Name { set; get; }

        public string State {
            set
            {
                if (value == "в разработке" || value == "выпущен" || value == "стабильный" || value == "устарел")
                {
                    state = value;
                }
                else
                {
                    state = "";
                }
            }
            get
            {
                return state;
            }
        }

        public bool Inheritance { set; get; }

        public string Visibility
        {
            set
            {
                if (value == "приватный" || value == "публичный")
                {
                    visibility = value;
                }
                else
                {
                    visibility = "";
                }
            }

            get
            {
                return visibility;
            }
        }

        public string Description { set; get; }

        public override string ToString()
        {
            return "<Name: " + Name + "; " + State + "; " + Visibility + "; " + Description +  ">";
        }

        public int CompareTo(ProjectData other) 
        {
            if (object.ReferenceEquals(other, null)) 
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
    }
}
