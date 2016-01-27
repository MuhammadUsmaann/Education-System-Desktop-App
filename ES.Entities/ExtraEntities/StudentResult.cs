using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public class StudentResultCard : IBaseEntity
    {
        
        private string m_SubjectName;

        private decimal m_Exam1 = 0;
        private decimal m_Exam2 = 0;
        private decimal m_Exam3 = 0;
        private decimal m_Exam4 = 0;
        private decimal m_Exam5 = 0;
        private decimal m_Exam6 = 0;
        private decimal m_Exam7 = 0;
        private decimal m_Exam8 = 0;
        private decimal m_Exam9 = 0;
        private decimal m_Exam10 = 0;
        private decimal m_Exam11 = 0;
        private decimal m_Exam12 = 0;
        private decimal m_Exam13 = 0;
        private decimal m_Exam14 = 0;
        private decimal m_Exam15 = 0;
        private decimal m_Exam16 = 0;
        private decimal m_Exam17 = 0;
        private decimal m_Exam18 = 0;
        private decimal m_Exam19 = 0;
        private decimal m_Exam20 = 0;


        public string SubjectName
        {
            get { return m_SubjectName; }
            set
            {
                if (m_SubjectName != value)
                {
                    m_SubjectName = value;
                    NotifyPropertyChanged("SubjectName");
                }
            }
        }
        
        public decimal Exam1
        {
            get { return m_Exam1; }
            set { m_Exam1 = value; NotifyPropertyChanged("Exam1"); }
        }
        public decimal Exam2
        {
            get { return m_Exam2; }
            set { m_Exam2 = value; NotifyPropertyChanged("Exam2"); }
        }
        public decimal Exam3
        {
            get { return m_Exam3; }
            set { m_Exam3 = value; NotifyPropertyChanged("Exam3"); }
        }
        public decimal Exam4
        {
            get { return m_Exam4; }
            set { m_Exam4 = value; NotifyPropertyChanged("Exam4"); }
        }
        public decimal Exam5
        {
            get { return m_Exam5; }
            set { m_Exam5 = value; NotifyPropertyChanged("Exam5"); }
        }
        public decimal Exam6
        {
            get { return m_Exam6; }
            set { m_Exam6 = value; NotifyPropertyChanged("Exam6"); }
        }
        public decimal Exam7
        {
            get { return m_Exam7; }
            set { m_Exam7 = value; NotifyPropertyChanged("Exam7"); }
        }
        public decimal Exam8
        {
            get { return m_Exam8; }
            set { m_Exam8 = value; NotifyPropertyChanged("Exam8"); }
        }
        public decimal Exam9
        {
            get { return m_Exam9; }
            set { m_Exam9 = value; NotifyPropertyChanged("Exam9"); }
        }
        public decimal Exam10
        {
            get { return m_Exam10; }
            set { m_Exam10 = value; NotifyPropertyChanged("Exam10"); }
        }
        public decimal Exam11
        {
            get { return m_Exam11; }
            set { m_Exam11 = value; NotifyPropertyChanged("Exam11"); }
        }
        public decimal Exam12
        {
            get { return m_Exam12; }
            set { m_Exam12 = value; NotifyPropertyChanged("Exam12"); }
        }
        public decimal Exam13
        {
            get { return m_Exam13; }
            set { m_Exam13 = value; NotifyPropertyChanged("Exam13"); }
        }
        public decimal Exam14
        {
            get { return m_Exam14; }
            set { m_Exam14 = value; NotifyPropertyChanged("Exam14"); }
        }
        public decimal Exam15
        {
            get { return m_Exam15; }
            set { m_Exam15 = value; NotifyPropertyChanged("Exam15"); }
        }
        public decimal Exam16
        {
            get { return m_Exam16; }
            set { m_Exam16 = value; NotifyPropertyChanged("Exam16"); }
        }
        public decimal Exam17
        {
            get { return m_Exam17; }
            set { m_Exam17 = value; NotifyPropertyChanged("Exam17"); }
        }
        public decimal Exam18
        {
            get { return m_Exam18; }
            set { m_Exam18 = value; NotifyPropertyChanged("Exam18"); }
        }
        public decimal Exam19
        {
            get { return m_Exam19; }
            set { m_Exam19 = value; NotifyPropertyChanged("Exam19"); }
        }
        public decimal Exam20
        {
            get { return m_Exam20; }
            set { m_Exam20 = value; NotifyPropertyChanged("Exam20"); }
        }



    }
}
