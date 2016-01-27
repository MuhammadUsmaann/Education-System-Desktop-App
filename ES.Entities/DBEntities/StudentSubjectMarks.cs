 using System;

 namespace ES.Entities
 {
	public partial class StudentSubjectMarks : IBaseEntity
	{
		private int m_id;
		private int m_classid;
		private int m_studentid;
		private int m_examid;
		private int m_subjectid;
		private int m_sectionid;
		private decimal m_obtainedmarks;
		private int m_totalmarks;
		private bool m_isactive;
		private int m_created_by;
		private int m_updated_by;
		private string m_creation_date;
		private string m_updated_date;
		private int m_sessionid;

		public int ID
		{
			get { return  m_id; } 
			set{ m_id = value; NotifyPropertyChanged("ID"); }
		}

		public int ClassID
		{
			get { return  m_classid; } 
			set{ m_classid = value; NotifyPropertyChanged("ClassID"); }
		}

		public int StudentID
		{
			get { return  m_studentid; } 
			set{ m_studentid = value; NotifyPropertyChanged("StudentID"); }
		}

		public int ExamID
		{
			get { return  m_examid; } 
			set{ m_examid = value; NotifyPropertyChanged("ExamID"); }
		}

		public int SubjectID
		{
			get { return  m_subjectid; } 
			set{ m_subjectid = value; NotifyPropertyChanged("SubjectID"); }
		}

		public int SectionID
		{
			get { return  m_sectionid; } 
			set{ m_sectionid = value; NotifyPropertyChanged("SectionID"); }
		}

		public decimal ObtainedMarks
		{
			get { return  m_obtainedmarks; } 
			set{ m_obtainedmarks = value; NotifyPropertyChanged("ObtainedMarks"); }
		}

		public int TotalMarks
		{
			get { return  m_totalmarks; } 
			set{ m_totalmarks = value; NotifyPropertyChanged("TotalMarks"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
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

		public int SessionID
		{
			get { return  m_sessionid; } 
			set{ m_sessionid = value; NotifyPropertyChanged("SessionID"); }
		}

	}
}