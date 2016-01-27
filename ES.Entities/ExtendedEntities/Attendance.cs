
namespace ES.Entities
{
    public partial class Attendance
    {
        private string _studentName;
        private string _roleNumber;

        public string RoleNumber
        {
            get { return _roleNumber; }
            set
            {
                if (_roleNumber != value)
                {
                    _roleNumber = value;
                    NotifyPropertyChanged("RoleNumber");
                }
            }
        }

        public string pFirstName { get; set; }
        public string pLastName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentName
        {
            get { return FirstName + " " + LastName; }
            set
            {
                if (_studentName != value)
                {
                    _studentName = value;
                    NotifyPropertyChanged("StudentName");
                }
            }
        }
    }
}
