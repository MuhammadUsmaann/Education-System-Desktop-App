using System.Collections.Generic;
using ES.Configurations;

namespace ES.Entities
{
    public partial class UsersDetail
    {
        private List<string> m_genderList ;
        private List<string> m_roleTypes;
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
    }
}
