 using System;

 namespace ES.Entities
 {
	public partial class Grade : IBaseEntity
	{
		private int m_gradeid;
		private string m_gradename;
		private decimal m_percentage;
		private string m_comment;
		private int m_created_by;
		private int m_updated_by;
		private string m_creation_date;
		private string m_updated_date;
		private bool m_isactive;

		public int GradeID
		{
			get { return  m_gradeid; } 
			set{ m_gradeid = value; NotifyPropertyChanged("GradeID"); }
		}

		public string GradeName
		{
			get { return  m_gradename; } 
			set{ m_gradename = value; NotifyPropertyChanged("GradeName"); }
		}

		public decimal Percentage
		{
			get { return  m_percentage; } 
			set{ m_percentage = value; NotifyPropertyChanged("Percentage"); }
		}

		public string Comment
		{
			get { return  m_comment; } 
			set{ m_comment = value; NotifyPropertyChanged("Comment"); }
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