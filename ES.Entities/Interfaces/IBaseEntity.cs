using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public class IBaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Boolean _isNew = false;
        
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        protected string GetCurrentDate()
        {
            DateTime dateAndTime = DateTime.Now;
            //return dateAndTime.ToString("MM-dd-yyyy");
            return dateAndTime.ToString();
        }
        public Boolean isNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                _isNew = value;
            }
        }
    }
}
