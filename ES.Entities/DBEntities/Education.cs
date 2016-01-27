 using System;

 namespace ES.Entities
 {
	public partial class Education : IBaseEntity
	{
		private int m_educationid;
		private string m_description;
		private int m_passyear;
		private string m_score;
		private int m_userid;
		private string m_institution;
		private bool m_isactive;

		public int EducationID
		{
			get { return  m_educationid; } 
			set{ m_educationid = value; NotifyPropertyChanged("EducationID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public int PassYear
		{
			get { return  m_passyear; } 
			set{ m_passyear = value; NotifyPropertyChanged("PassYear"); }
		}

		public string score
		{
			get { return  m_score; } 
			set{ m_score = value; NotifyPropertyChanged("score"); }
		}

		public int UserID
		{
			get { return  m_userid; } 
			set{ m_userid = value; NotifyPropertyChanged("UserID"); }
		}

		public string Institution
		{
			get { return  m_institution; } 
			set{ m_institution = value; NotifyPropertyChanged("Institution"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}