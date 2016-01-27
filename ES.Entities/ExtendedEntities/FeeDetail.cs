using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public partial class FeeDetail
    {
        private string m_roleNumber;
        private string m_studentName;
        private string m_parentName;
        private string m_joningDate;
        private string m_sectionName;
        private string m_className;

        public string ClassName
        {
            get
            {
                return m_className;
            }
            set
            {
                m_className = value;
                NotifyPropertyChanged("ClassName");
            }
        }
        public string SectionName
        {
            get
            {
                return m_sectionName;
            }
            set
            {
                m_sectionName = value;
                NotifyPropertyChanged("SectionName");
            }
        }

        public string pFirstName { get; set; }
        public string pLastName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentRoleNumber {
            get
            {
                return m_roleNumber;
            }
            set
            {
                m_roleNumber = value;
                NotifyPropertyChanged("StudentRoleNumber");
            }
        }
        public string StudentName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {
                m_studentName = value;
                NotifyPropertyChanged("StudentName");
            }
        }
        public string ParentName
        {
            get
            {
                return pFirstName + " " + pLastName;
            }
            set
            {
                m_parentName = value;
                NotifyPropertyChanged("ParentName");
            }
        }

        public string JoiningDate
        {
            get
            {
                return m_joningDate;
            }
            set
            {
                m_joningDate = value;
                NotifyPropertyChanged("JoningDate");
            }
        }

        public bool isUpdated { get; set; }
    }
}
