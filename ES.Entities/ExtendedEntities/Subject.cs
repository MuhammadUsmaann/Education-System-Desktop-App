using ES.Configurations;
using System.Collections.Generic;

namespace ES.Entities
{
    public partial class Subject
    {
        private string m_isCompusory = null;
        private string m_isScience = null;
        private List<string> _subjectList;
        private List<string> _subjectCompulosryList;
        private int _classCount;
        private int _studentCount;

        private string m_typeDescription;
        private string m_CompulsoryDescription;
        public string TypeDescription
        {
            get
            {
                return m_typeDescription;
            }
            set
            {
                m_typeDescription = value;
                NotifyPropertyChanged("TypeDescription");
            }
        }
        public string CompulsoryDescription
        {
            get
            {
                return m_CompulsoryDescription;
            }
            set
            {
                m_CompulsoryDescription = value;
                NotifyPropertyChanged("CompulsoryDescription");
            }
        }
        
        public string SubjectType
        {
            get
            {
                return m_isCompusory;
            }
            set
            {
                m_isCompusory = value;
            }
        }
        public int ClassCount
        {
            get
            {
                return _classCount;
            }
            set
            {
                if (_classCount != value)
                {
                    _classCount = value;
                    NotifyPropertyChanged("ClassCount");
                }
            }
        }
        public int StudentCount
        {
            get
            {
                return _studentCount;
            }
            set
            {
                if (_studentCount != value)
                {
                    _studentCount = value;
                    NotifyPropertyChanged("StudentCount");
                }
            }
        }
        public bool isSelected { get; set; }
    }
}
