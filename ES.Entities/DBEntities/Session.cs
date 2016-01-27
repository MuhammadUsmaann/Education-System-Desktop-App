 using System;

 namespace ES.Entities
 {
	public partial class Session : IBaseEntity
	{
		private int m_sessionid;
		private string m_startdate;
		private string m_enddate;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private string m_description;
		private bool m_isactive;

		public int SessionID
		{
			get { return  m_sessionid; } 
			set{ m_sessionid = value; NotifyPropertyChanged("SessionID"); }
		}

		public string StartDate
		{
			get { return  m_startdate; } 
			set{ m_startdate = value; NotifyPropertyChanged("StartDate"); }
		}

		public string EndDate
		{
			get { return  m_enddate; } 
			set{ m_enddate = value; NotifyPropertyChanged("EndDate"); }
		}

		public string creation_date
		{
			get { return GetCurrentDate(); } 
			set{ m_creation_date = value; NotifyPropertyChanged("creation_date"); }
		}

		public string updated_date
		{
			get { return GetCurrentDate(); } 
			set{ m_updated_date = value; NotifyPropertyChanged("updated_date"); }
		}

		public int created_by
		{
			get { return  m_created_by; } 
			set{ m_created_by = value; NotifyPropertyChanged("created_by"); }
		}

		public int updated_by
		{
			get { return  m_updated_by; } 
			set{ m_updated_by = value; NotifyPropertyChanged("updated_by"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}