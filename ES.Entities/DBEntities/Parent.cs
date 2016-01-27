 using System;

 namespace ES.Entities
 {
	public partial class Parent : IBaseEntity
	{
		private int m_parentid;
		private string m_firstname;
		private string m_middlename;
		private string m_lastname;
		private string m_address;
		private string m_email;
		private string m_contactno1;
		private string m_contactno2;
		private string m_cnic;
		private int m_income;
		private string m_creation_date;
		private string m_updated_date;
		private int m_updated_by;
		private int m_created_by;
		private bool m_isactive;

		public int ParentID
		{
			get { return  m_parentid; } 
			set{ m_parentid = value; NotifyPropertyChanged("ParentID"); }
		}

		public string FirstName
		{
			get { return  m_firstname; } 
			set{ m_firstname = value; NotifyPropertyChanged("FirstName"); }
		}

		public string MiddleName
		{
			get { return  m_middlename; } 
			set{ m_middlename = value; NotifyPropertyChanged("MiddleName"); }
		}

		public string LastName
		{
			get { return  m_lastname; } 
			set{ m_lastname = value; NotifyPropertyChanged("LastName"); }
		}

		public string Address
		{
			get { return  m_address; } 
			set{ m_address = value; NotifyPropertyChanged("Address"); }
		}

		public string Email
		{
			get { return  m_email; } 
			set{ m_email = value; NotifyPropertyChanged("Email"); }
		}

		public string ContactNo1
		{
			get { return  m_contactno1; } 
			set{ m_contactno1 = value; NotifyPropertyChanged("ContactNo1"); }
		}

		public string ContactNo2
		{
			get { return  m_contactno2; } 
			set{ m_contactno2 = value; NotifyPropertyChanged("ContactNo2"); }
		}

		public string CNIC
		{
			get { return  m_cnic; } 
			set{ m_cnic = value; NotifyPropertyChanged("CNIC"); }
		}

		public int Income
		{
			get { return  m_income; } 
			set{ m_income = value; NotifyPropertyChanged("Income"); }
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

	}
}