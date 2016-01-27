 using System;

 namespace ES.Entities
 {
	public partial class Roles : IBaseEntity
	{
		private int m_roleid;
		private string m_description;
		private string m_rolecode;
		private bool m_isactive;

		public int RoleID
		{
			get { return  m_roleid; } 
			set{ m_roleid = value; NotifyPropertyChanged("RoleID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public string RoleCode
		{
			get { return  m_rolecode; } 
			set{ m_rolecode = value; NotifyPropertyChanged("RoleCode"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}