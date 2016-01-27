 using System;

 namespace ES.Entities
 {
	public partial class Attendance : IBaseEntity
	{
		private int m_id;
		private int m_classid;
		private int m_studentid;
		private int m_sessionid;
		private string m_attendancedate;
		private string m_updated_date;
		private string m_creation_date;
		private int m_updated_by;
		private int m_created_by;
		private bool m_isactive;
		private bool m_ispresent;
		private int m_sectionid;

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

		public int SessionID
		{
			get { return  m_sessionid; } 
			set{ m_sessionid = value; NotifyPropertyChanged("SessionID"); }
		}

		public string AttendanceDate
		{
			get { return  m_attendancedate; } 
			set{ m_attendancedate = value; NotifyPropertyChanged("AttendanceDate"); }
		}

		public string updated_date
		{
			get { return GetCurrentDate(); } 
			set{ m_updated_date = value; NotifyPropertyChanged("updated_date"); }
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

		public int created_by
		{
			get { return  m_created_by; } 
			set{ m_created_by = value; NotifyPropertyChanged("created_by"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

		public bool isPresent
		{
			get { return  m_ispresent; } 
			set{ m_ispresent = value; NotifyPropertyChanged("isPresent"); }
		}

		public int SectionID
		{
			get { return  m_sectionid; } 
			set{ m_sectionid = value; NotifyPropertyChanged("SectionID"); }
		}

	}
}