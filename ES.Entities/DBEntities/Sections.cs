 using System;

 namespace ES.Entities
 {
	public partial class Sections : IBaseEntity
	{
		private int m_sectionid;
		private string m_description;
		private bool m_isactive;

		public int SectionID
		{
			get { return  m_sectionid; } 
			set{ m_sectionid = value; NotifyPropertyChanged("SectionID"); }
		}

		public string Description
		{
			get { return  m_description; } 
			set{ m_description = value; NotifyPropertyChanged("Description"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

	}
}