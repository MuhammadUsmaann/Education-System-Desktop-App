using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public class ClassResult : IBaseEntity
    {
        private string m_studentName = null;
        private string m_rolenumber = null;

        private decimal m_Subject1 = 0;
        private decimal m_Subject2 = 0;
        private decimal m_Subject3 = 0;
        private decimal m_Subject4 = 0;
        private decimal m_Subject5 = 0;
        private decimal m_Subject6 = 0;
        private decimal m_Subject7 = 0;
        private decimal m_Subject8 = 0;
        private decimal m_Subject9 = 0;
        private decimal m_Subject10 = 0;
        private decimal m_Subject11 = 0;
        private decimal m_Subject12 = 0;
        private decimal m_Subject13 = 0;
        private decimal m_Subject14 = 0;
        private decimal m_Subject15 = 0;
        private decimal m_Subject16 = 0;
        private decimal m_Subject17 = 0; 
        private decimal m_Subject18 = 0;
        private decimal m_Subject19 = 0;
        private decimal m_Subject20 = 0;

        public string StudentName
        {
            get
            {
                return m_studentName;
            }
            set
            {
                if (m_studentName != value)
                {
                    m_studentName = value;
                    NotifyPropertyChanged("StudentName");
                }
            }
        }
        public string RoleNumber
        {
            get
            {
                return m_rolenumber;
            }
            set
            {
                if (m_rolenumber != value)
                {
                    m_rolenumber = value;
                    NotifyPropertyChanged("RoleNumber");
                }
            }
        }

        public decimal Subject1
        {
            get { return m_Subject1; }
            set { m_Subject1 = value; NotifyPropertyChanged("Subject1"); }
        }
        public decimal Subject2
        {
            get { return m_Subject2; }
            set { m_Subject2 = value; NotifyPropertyChanged("Subject2"); }
        }
        public decimal Subject3
        {
            get { return m_Subject3; }
            set { m_Subject3 = value; NotifyPropertyChanged("Subject3"); }
        }
        public decimal Subject4
        {
            get { return m_Subject4; }
            set { m_Subject4 = value; NotifyPropertyChanged("Subject4"); }
        }
        public decimal Subject5
        {
            get { return m_Subject5; }
            set { m_Subject5 = value; NotifyPropertyChanged("Subject5"); }
        }
        public decimal Subject6
        {
            get { return m_Subject6; }
            set { m_Subject6 = value; NotifyPropertyChanged("Subject6"); }
        }
        public decimal Subject7
        {
            get { return m_Subject7; }
            set { m_Subject7 = value; NotifyPropertyChanged("Subject7"); }
        }
        public decimal Subject8
        {
            get { return m_Subject8; }
            set { m_Subject8 = value; NotifyPropertyChanged("Subject8"); }
        }
        public decimal Subject9
        {
            get { return m_Subject9; }
            set { m_Subject9 = value; NotifyPropertyChanged("Subject9"); }
        }
        public decimal Subject10
        {
            get { return m_Subject10; }
            set { m_Subject10 = value; NotifyPropertyChanged("Subject10"); }
        }
        public decimal Subject11
        {
            get { return m_Subject11; }
            set { m_Subject11 = value; NotifyPropertyChanged("Subject11"); }
        }
        public decimal Subject12
        {
            get { return m_Subject12; }
            set { m_Subject12 = value; NotifyPropertyChanged("Subject12"); }
        }
        public decimal Subject13
        {
            get { return m_Subject13; }
            set { m_Subject13 = value; NotifyPropertyChanged("Subject13"); }
        }
        public decimal Subject14
        {
            get { return m_Subject14; }
            set { m_Subject14 = value; NotifyPropertyChanged("Subject14"); }
        }
        public decimal Subject15
        {
            get { return m_Subject15; }
            set { m_Subject15 = value; NotifyPropertyChanged("Subject15"); }
        }
        public decimal Subject16
        {
            get { return m_Subject16; }
            set { m_Subject16 = value; NotifyPropertyChanged("Subject16"); }
        }
        public decimal Subject17
        {
            get { return m_Subject17; }
            set { m_Subject17 = value; NotifyPropertyChanged("Subject17"); }
        }
        public decimal Subject18
        {
            get { return m_Subject18; }
            set { m_Subject18 = value; NotifyPropertyChanged("Subject18"); }
        }
        public decimal Subject19
        {
            get { return m_Subject19; }
            set { m_Subject19 = value; NotifyPropertyChanged("Subject19"); }
        }
        public decimal Subject20
        {
            get { return m_Subject20; }
            set { m_Subject20 = value; NotifyPropertyChanged("Subject20"); }
        }
    }
}
