 using System;

 namespace ES.Entities
 {
	public partial class ClassStudent : IBaseEntity
	{
		private int m_id;
		private int m_classid;
		private int m_studentid;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private bool m_isactive;

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

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}