 using System;

 namespace ES.Entities
 {
	public partial class Subject : IBaseEntity
	{
		private int m_subjectid;
		private string m_description;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private string m_type;
		private string m_compulsory;
		private bool m_isactive;

		public int SubjectID
		{
			get { return  m_subjectid; } 
			set{ m_subjectid = value; NotifyPropertyChanged("SubjectID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
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

		public string Type
		{
			get { return  m_type; } 
			set{ m_type = value; NotifyPropertyChanged("Type"); }
		}

		public string Compulsory
		{
			get { return  m_compulsory; } 
			set{ m_compulsory = value; NotifyPropertyChanged("Compulsory"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}