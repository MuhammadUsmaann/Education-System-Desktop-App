namespace ES.Entities
{
    public partial class Class 
    {
        private int _stdCount;
        public int StudentCount
        {
            get
            {
                return _stdCount;
            }
            set
            {
                if(_stdCount != value)
                {
                    _stdCount = value;
                    NotifyPropertyChanged("StudentCount");
                }
            }
        }
    }
}
