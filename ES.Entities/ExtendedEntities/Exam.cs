
using System.Collections.Generic;
using ES.Configurations;
namespace ES.Entities
{
    public partial class Exam
    {
        public Exam() {
            var asd = TypeList;
        }
        public string TempID { get; set; }
        IEnumerable<CustomDropDownValues> _typeList;
        public IEnumerable<CustomDropDownValues> TypeList
        {
            get
            {
                if(_typeList == null)
                {
                    _typeList = _typeList.Add(new CustomDropDownValues {DisplayName = "Mandatory" , DisplayID = 1.ToString()});
                    _typeList = _typeList.Add(new CustomDropDownValues { DisplayName = "General", DisplayID = 2.ToString() });
                }
                return _typeList;
            }
            set
            {

                NotifyPropertyChanged("TypeList");
            }
        }
    }
}
