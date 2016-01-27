 using System;

 namespace ES.Entities
 {
	public partial class StudentFee : IBaseEntity
	{
		private int m_studentfeeid;
		private string m_feetype;
		private int m_decidedfee;
		private int m_studentid;
		private int m_sessionid;
		private int m_created_by;
		private string m_creation_date;
		private int m_updated_by;
		private string m_updated_date;

		public int StudentFeeID
		{
			get { return  m_studentfeeid; } 
			set{ m_studentfeeid = value; NotifyPropertyChanged("StudentFeeID"); }
		}

		public string FeeType
		{
			get { return  m_feetype; } 
			set{ m_feetype = value; NotifyPropertyChanged("FeeType"); }
		}

		public int DecidedFee
		{
			get { return  m_decidedfee; } 
			set{ m_decidedfee = value; NotifyPropertyChanged("DecidedFee"); }
		}

		public int StudentID
		{
			get { return  m_studentid; } 
			set{ m_studentid = value; NotifyPropertyChanged("StudentID"); }
		}

		public int SessionID
		{
			get { return  m_sessionid; } 
			set{ m_sessionid = value; NotifyPropertyChanged("SessionID"); }
		}

		public int created_by
		{
			get { return  m_created_by; } 
			set{ m_created_by = value; NotifyPropertyChanged("created_by"); }
		}

		public string creation_date
		{
			get { return GetCurrentDate(); } 
			set{ m_creation_date = value; NotifyPropertyChanged("creation_date"); }
		}

		public int updated_by
		{
			get { return  m_updated_by; } 
			set{ m_updated_by = value; NotifyPropertyChanged("updated_by"); }
		}

		public string updated_date
		{
			get { return GetCurrentDate(); } 
			set{ m_updated_date = value; NotifyPropertyChanged("updated_date"); }
		}

	}
}