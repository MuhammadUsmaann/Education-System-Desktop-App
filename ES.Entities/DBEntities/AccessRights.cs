 using System;

 namespace ES.Entities
 {
	public partial class AccessRights : IBaseEntity
	{
		private int m_accessrightid;
		private string m_description;
		private string m_controlid;
		private int m_userid;
		private bool m_canedit;
		private bool m_canview;
		private bool m_candelete;
		private bool m_isactive;

		public int AccessRightID
		{
			get { return  m_accessrightid; } 
			set{ m_accessrightid = value; NotifyPropertyChanged("AccessRightID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public string ControlID
		{
			get { return  m_controlid; } 
			set{ m_controlid = value; NotifyPropertyChanged("ControlID"); }
		}

		public int UserID
		{
			get { return  m_userid; } 
			set{ m_userid = value; NotifyPropertyChanged("UserID"); }
		}

		public bool CanEdit
		{
			get { return  m_canedit; } 
			set{ m_canedit = value; NotifyPropertyChanged("CanEdit"); }
		}

		public bool CanView
		{
			get { return  m_canview; } 
			set{ m_canview = value; NotifyPropertyChanged("CanView"); }
		}

		public bool CanDelete
		{
			get { return  m_candelete; } 
			set{ m_candelete = value; NotifyPropertyChanged("CanDelete"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}