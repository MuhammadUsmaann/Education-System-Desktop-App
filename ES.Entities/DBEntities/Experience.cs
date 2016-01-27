 using System;

 namespace ES.Entities
 {
	public partial class Experience : IBaseEntity
	{
		private int m_experienceid;
		private string m_description;
		private string m_startdate;
		private string m_enddate;
		private string m_institution;
		private int m_userid;
		private bool m_isactive;

		public int ExperienceID
		{
			get { return  m_experienceid; } 
			set{ m_experienceid = value; NotifyPropertyChanged("ExperienceID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
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

		public string Institution
		{
			get { return  m_institution; } 
			set{ m_institution = value; NotifyPropertyChanged("Institution"); }
		}

		public int UserID
		{
			get { return  m_userid; } 
			set{ m_userid = value; NotifyPropertyChanged("UserID"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}