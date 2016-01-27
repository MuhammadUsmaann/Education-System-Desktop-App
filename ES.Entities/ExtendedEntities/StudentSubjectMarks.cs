using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public partial class StudentSubjectMarks
    {
        private string _studentName;
        private string _studentRoleNumber;
        private string m_SubjectName;

        public string SubjectName
        {
            get
            {
                return m_SubjectName;
            }
            set
            {
                if (m_SubjectName != value)
                {
                    m_SubjectName = value;
                    NotifyPropertyChanged("SubjectName");
                }
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {
                if (_studentName != value)
                {
                    _studentName = value;
                    NotifyPropertyChanged("StudentName");
                }
            }
        }
        public string StudentRoleNumber
        {
            get
            {
                return _studentRoleNumber;
            }
            set
            {
                if (_studentRoleNumber != value)
                {
                    _studentRoleNumber = value;
                    NotifyPropertyChanged("StudentRoleNumber");
                }
            }
        }
    }
}
