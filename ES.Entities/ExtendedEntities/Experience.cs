using System;

namespace ES.Entities
{
    public partial class Experience : IBaseEntity
    {

        double _totleExperience = 0;
        string _startdateString = "";
        public double TotalExperince
        {
            get
            {
                return _totleExperience;
            }
            set
            {
                if (_totleExperience != value)
                {
                    _totleExperience = value;
                    NotifyPropertyChanged("TotleExperince");
                }
            }
        }

        public string StartDateString
        {
            get
            {
                return _startdateString;
            }
            set
            {
                if(_startdateString != value)
                {
                    _startdateString = value;
                    NotifyPropertyChanged("StartDateString");
                }
            }
        }
    }
}
