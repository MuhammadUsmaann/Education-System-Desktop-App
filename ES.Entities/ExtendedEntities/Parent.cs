
namespace ES.Entities
{
    public partial class Parent 
    {
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
