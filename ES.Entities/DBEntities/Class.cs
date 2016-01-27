 using System;

 namespace ES.Entities
 {
	public partial class Class : IBaseEntity
	{
		private int m_classid;
		private string m_description;
		private int m_classnumber;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private int m_branchid;
		private bool m_isactive;

		public int ClassID
		{
			get { return  m_classid; } 
			set{ m_classid = value; NotifyPropertyChanged("ClassID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public int ClassNumber
		{
			get { return  m_classnumber; } 
			set{ m_classnumber = value; NotifyPropertyChanged("ClassNumber"); }
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

		public int BranchID
		{
			get { return  m_branchid; } 
			set{ m_branchid = value; NotifyPropertyChanged("BranchID"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}