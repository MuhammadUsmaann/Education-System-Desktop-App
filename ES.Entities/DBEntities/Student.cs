 using System;

 namespace ES.Entities
 {
	public partial class Student : IBaseEntity
	{
		private int m_studentid;
		private string m_firstname;
		private string m_lastname;
		private string m_middlename;
		private string m_dateofbirth;
		private string m_admissiondate;
		private string m_registrationnumber;
		private string m_gender;
		private string m_phone;
		private int m_adminssionfee;
		private int m_examinationfee;
		private int m_monthlyfee;
		private int m_othercharges;
		private int m_discount;
		private int m_parentid;
		private int m_classid;
		private string m_creation_date;
		private string m_updated_date;
		private int m_created_by;
		private int m_updated_by;
		private bool m_isactive;
		private int m_sectionid;

		public int StudentID
		{
			get { return  m_studentid; } 
			set{ m_studentid = value; NotifyPropertyChanged("StudentID"); }
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

		public string DateOfBirth
		{
			get { return  m_dateofbirth; } 
			set{ m_dateofbirth = value; NotifyPropertyChanged("DateOfBirth"); }
		}

		public string AdmissionDate
		{
			get { return  m_admissiondate; } 
			set{ m_admissiondate = value; NotifyPropertyChanged("AdmissionDate"); }
		}

		public string RegistrationNumber
		{
			get { return  m_registrationnumber; } 
			set{ m_registrationnumber = value; NotifyPropertyChanged("RegistrationNumber"); }
		}

		public string Gender
		{
			get { return  m_gender; } 
			set{ m_gender = value; NotifyPropertyChanged("Gender"); }
		}

		public string Phone
		{
			get { return  m_phone; } 
			set{ m_phone = value; NotifyPropertyChanged("Phone"); }
		}

		public int AdminssionFee
		{
			get { return  m_adminssionfee; } 
			set{ m_adminssionfee = value; NotifyPropertyChanged("AdminssionFee"); }
		}

		public int ExaminationFee
		{
			get { return  m_examinationfee; } 
			set{ m_examinationfee = value; NotifyPropertyChanged("ExaminationFee"); }
		}

		public int MonthlyFee
		{
			get { return  m_monthlyfee; } 
			set{ m_monthlyfee = value; NotifyPropertyChanged("MonthlyFee"); }
		}

		public int OtherCharges
		{
			get { return  m_othercharges; } 
			set{ m_othercharges = value; NotifyPropertyChanged("OtherCharges"); }
		}

		public int Discount
		{
			get { return  m_discount; } 
			set{ m_discount = value; NotifyPropertyChanged("Discount"); }
		}

		public int ParentID
		{
			get { return  m_parentid; } 
			set{ m_parentid = value; NotifyPropertyChanged("ParentID"); }
		}

		public int ClassID
		{
			get { return  m_classid; } 
			set{ m_classid = value; NotifyPropertyChanged("ClassID"); }
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

		public int SectionID
		{
			get { return  m_sectionid; } 
			set{ m_sectionid = value; NotifyPropertyChanged("SectionID"); }
		}

	}
}