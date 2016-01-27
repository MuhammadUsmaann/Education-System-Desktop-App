using System.Collections.Generic;
using ES.Configurations;

namespace ES.Entities
{
    public partial class Student
    {
        List<string> m_genderList;
        private string _parentName;
        private string _address;
        private string m_className;
        public string pFirstName { get; set; }
        public string pLastName { get; set; }
        public string ParentName
        {
            get
            {
                return _parentName;
            }
            set
            {
                if (_parentName != value)
                {
                    _parentName = value;
                    NotifyPropertyChanged("ParentName");
                }
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
            set
            {
                    NotifyPropertyChanged("FullName");
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }
        public string ClassName
        {

            get
            {
                return m_className;
            }
            set
            {
                if (m_className != value)
                {
                    m_className = value;
                    NotifyPropertyChanged("ClassName");
                }
            }
        }
    }
}
