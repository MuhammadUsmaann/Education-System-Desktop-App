 using System;

 namespace ES.Entities
 {
	public partial class Exam : IBaseEntity
	{
		private int m_examid;
		private string m_description;
		private bool m_type;
		private string m_comment;
		private int m_created_by;
		private int m_updated_by;
		private string m_creation_date;
		private string m_updated_date;
		private bool m_isactive;

		public int ExamID
		{
			get { return  m_examid; } 
			set{ m_examid = value; NotifyPropertyChanged("ExamID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public bool Type
		{
			get { return  m_type; } 
			set{ m_type = value; NotifyPropertyChanged("Type"); }
		}

		public string comment
		{
			get { return  m_comment; } 
			set{ m_comment = value; NotifyPropertyChanged("comment"); }
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

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}