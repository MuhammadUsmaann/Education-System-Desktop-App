using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public class StudentAttendance : IBaseEntity
    {
        private bool _ispresent;
        private string _dayName;
        private int _dayCount;
        private bool _isExisted = false;
        public bool isPresent
        {
            get { return _ispresent; }
            set
            {
                if(_ispresent != value)
                {
                    _ispresent = value;
                    NotifyPropertyChanged("isPresent");
                }
            }
        }
        public string DayName
        {
            get { return _dayName; }
            set
            {
                if (_dayName != value)
                {
                    _dayName = value;
                    NotifyPropertyChanged("DayName");
                }
            }
        }
        public int DayNumber
        {
            get { return _dayCount; }
            set
            {
                if (_dayCount != value)
                {
                    _dayCount = value;
                    NotifyPropertyChanged("DayNumber");
                }
            }
        }
        public bool isExisted
        {
            get { return _isExisted; }
            set
            {
                if(_isExisted != value)
                {
                    _isExisted = value;
                    NotifyPropertyChanged("isExisted");
                }
            }
        }
    }
}
