 using System;

 namespace ES.Entities
 {
	public partial class UsersDetail : IBaseEntity
	{
		private int m_id;
		private string m_firstname;
		private string m_lastname;
		private string m_middlename;
		private string m_dob;
		private string m_cnic;
		private string m_contactno1;
		private string m_contactno2;
		private string m_emailid;
		private int m_salary;
		private int m_userid;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private string m_gender;
		private string m_address;
		private bool m_isactive;
		private string m_joining_date;
		private string m_fathername;

		public int ID
		{
			get { return  m_id; } 
			set{ m_id = value; NotifyPropertyChanged("ID"); }
		}

		public string FirstName
		{
			get { return  m_firstname; } 
			set{ m_firstname = value; NotifyPropertyChanged("FirstName"); }
		}

		public string LastName
		{
			get { return  m_lastname; } 
			set{ m_lastname = value; NotifyPropertyChanged("LastName"); }
		}

		public string MiddleName
		{
			get { return  m_middlename; } 
			set{ m_middlename = value; NotifyPropertyChanged("MiddleName"); }
		}

		public string dob
		{
			get { return  m_dob; } 
			set{ m_dob = value; NotifyPropertyChanged("dob"); }
		}

		public string CNIC
		{
			get { return  m_cnic; } 
			set{ m_cnic = value; NotifyPropertyChanged("CNIC"); }
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

		public string EmailID
		{
			get { return  m_emailid; } 
			set{ m_emailid = value; NotifyPropertyChanged("EmailID"); }
		}

		public int Salary
		{
			get { return  m_salary; } 
			set{ m_salary = value; NotifyPropertyChanged("Salary"); }
		}

		public int UserID
		{
			get { return  m_userid; } 
			set{ m_userid = value; NotifyPropertyChanged("UserID"); }
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

		public string Gender
		{
			get { return  m_gender; } 
			set{ m_gender = value; NotifyPropertyChanged("Gender"); }
		}

		public string Address
		{
			get { return  m_address; } 
			set{ m_address = value; NotifyPropertyChanged("Address"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

		public string Joining_date
		{
			get { return  m_joining_date; } 
			set{ m_joining_date = value; NotifyPropertyChanged("Joining_date"); }
		}

		public string FatherName
		{
			get { return  m_fathername; } 
			set{ m_fathername = value; NotifyPropertyChanged("FatherName"); }
		}

	}
}