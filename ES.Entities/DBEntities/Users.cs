 using System;

 namespace ES.Entities
 {
	public partial class Users : IBaseEntity
	{
		private int m_userid;
		private string m_username;
		private string m_password;
		private string m_roleid;
		private bool m_isactive;

		public int UserID
		{
			get { return  m_userid; } 
			set{ m_userid = value; NotifyPropertyChanged("UserID"); }
		}

		public string UserName
		{
			get { return  m_username; } 
			set{ m_username = value; NotifyPropertyChanged("UserName"); }
		}

		public string Password
		{
			get { return  m_password; } 
			set{ m_password = value; NotifyPropertyChanged("Password"); }
		}

		public string RoleID
		{
			get { return  m_roleid; } 
			set{ m_roleid = value; NotifyPropertyChanged("RoleID"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}